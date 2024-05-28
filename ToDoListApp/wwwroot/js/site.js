// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})

function submitEditForm() {
    var form = document.getElementById('editForm');
    var jobTitleInput = form.elements['JobTitle'];
    var jobDescriptionInput = form.elements['JobDescription'];

    var jobTitleValue = jobTitleInput.value.trim();
    var jobDescriptionValue = jobDescriptionInput.value.trim();

    if (jobTitleValue === '' || jobDescriptionValue === '')
    {
        alert('Please enter a value for Title and Description.');
        return false;
    }

    return true; 
}

function submitCreateForm() {
    var form = document.getElementById('createForm');
    var jobTitleInput = form.elements['JobTitle'];
    var jobDescriptionInput = form.elements['JobDescription'];

    var jobTitleValue = jobTitleInput.value.trim();
    var jobDescriptionValue = jobDescriptionInput.value.trim();

    if (jobTitleValue === '' || jobDescriptionValue === '') {
        alert('Please enter a value for Title and Description.');
        return false;
    }

    return true;
}

function updateCompletionStatus(checkbox) {
    var jobId = checkbox.dataset.jobid;
    var isChecked = checkbox.checked;

    // AJAX request to update the isCompleted property
    $.ajax({
        url: "/Home/UpdateCompletionStatus",
        type: "POST",
        data: {
            jobId: jobId,
            isChecked: isChecked
        },
        success: function (result) {
            console.log(result);
            location.reload(); //refrsh the page if successfull
        },
        error: function (error) {
            console.log(error); //print error
        }
    });
}