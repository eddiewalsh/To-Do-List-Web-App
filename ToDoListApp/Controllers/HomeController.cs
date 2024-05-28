using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        #region Dependancies and Variables Used
        private readonly IJobRepository jobRepository;
        private readonly IDataProtector dataProtectionProvider;
        public Jobs? NewTask { get; set; }
		#endregion

		public HomeController(IDataProtectionProvider dataProtection,IJobRepository jobrepo)
        {
            this.jobRepository = jobrepo;
            this.dataProtectionProvider = dataProtection.CreateProtector("MYKEYFORENCRYPTIONSDFSDFSD");
        }

        /// <summary>
        ///  We use our GetAll function to return into a list. From there we decrypt the data into a new
        ///  list and return decrypted data
        /// </summary>
        public IActionResult Index()
        {
            List<Jobs> jobs = jobRepository.GetAll();
            List<Jobs> DecryptedJobs = jobs.Select(job =>
            {
                if(job.JobTitle is not null) { job.JobTitle = dataProtectionProvider.Unprotect(job.JobTitle); }
				if (job.JobDescription is not null) { job.JobDescription = dataProtectionProvider.Unprotect(job.JobDescription); }
			
                return job;
            }).ToList();

            return View(DecryptedJobs);
        }

        /// <summary>
        ///  Call our partial view and use our public Jobs to bind the data in the following function
        /// </summary>
        public IActionResult Create()
        {
            return PartialView("_JobsPartialView", NewTask);
        }

        /// <summary>
        /// We verify our new Title and Desciption are not null than we decrypt our Title and 
        /// Description before adding it to our JobList in the JobRepository
        /// </summary>
        /// <param name="newjob">our new task created</param>
        [HttpPost]
        public IActionResult Create(Jobs newjob)
        {
			if (newjob.JobTitle is not null && newjob.JobDescription is not null)
			{
				newjob.JobTitle = dataProtectionProvider.Protect(newjob.JobTitle);
				newjob.JobDescription = dataProtectionProvider.Protect(newjob.JobDescription);
			}
            
            jobRepository.Add(newjob);
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// We get our object by calling our GetById() function in the ToDoListContext. From there, we 
        /// return our Edit Job modal along with the new found job
        /// </summary>
        /// <param name="id">The Id of the job we are looking for</param>
        public IActionResult Edit(int id)
        {
            Jobs? job = jobRepository.GetById(id);
			
            return PartialView("PartialView/_EditJobPartialView", job);
        }

        /// <summary>
        /// We verify our Title and Description are not null, than we encrypt the data, update our job repository list
        /// with the newly edited details and redirect back to the index page, which reloads the updated list
        /// </summary>
        /// <param name="editedjob"></param>
        [HttpPost]
        public IActionResult Edit(Jobs editedjob)
        {
            if (editedjob.JobTitle is not null && editedjob.JobDescription is not null)
            {
				editedjob.JobTitle = dataProtectionProvider.Protect(editedjob.JobTitle);
				editedjob.JobDescription = dataProtectionProvider.Protect(editedjob.JobDescription);
			}
			
            jobRepository.Update(editedjob);

		    return RedirectToAction("Index");
		}

		/// <summary>
		/// We get our object by calling our GetById() function in the ToDoListContext. From there, we 
		/// return our Delete Job modal along with the selected job we wish to delete
		/// </summary>
		/// <param name="id"></param>
		public IActionResult Delete(int id)
        {
            Jobs? job = jobRepository.GetById(id);
            
            return PartialView("PartialView/_DeleteJobPartialView", job);
        }

        /// <summary>
        /// Once the user confirms the deletion, we call our delete from our Job Repository and redirect our action 'Index' 
        /// This reloads the page without our deleted job
        /// </summary>
        /// <param name="job">The selected job we wish to delete</param>
        [HttpPost]
        public IActionResult Delete(Jobs job)
        {
            jobRepository.Delete(job);
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This function is called when the user ticks/unticks the checkbox in the Index on each job.
        /// We get our job based on the ID, and update the 'isCompleted' attribute based on the value passed. We update our
        /// list and send the success response if there is no issues
        /// </summary>
        /// <param name="jobId">The ID of the job we are updating</param>
        /// <param name="isChecked">the new bool value of isCompleted</param>
        [HttpPost]
        public IActionResult UpdateCompletionStatus(int jobId, bool isChecked)
        {
            Jobs? job = jobRepository.GetById(jobId);
            if (job != null)
            {
                job.isCompleted = isChecked;
                jobRepository.Update(job);
                
                return Ok(); // Return a success response if the update is successful
            }

            return NotFound();
        }
    }
}