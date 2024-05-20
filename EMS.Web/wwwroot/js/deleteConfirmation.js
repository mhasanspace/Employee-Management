document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.deleteButton').forEach(button => {
        button.addEventListener('click', function () {
            const divisionId = this.getAttribute('data-id');
            const deleteUrl = this.getAttribute('data-delete-url'); // Get the delete URL dynamically

            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Create a form element
                    const form = document.createElement('form');
                    form.method = 'post';
                    form.action = deleteUrl; // Set the action URL dynamically

                    // Create input element for orgDivId
                    const input = document.createElement('input');
                    input.type = 'hidden';
                    input.name = 'orgDivId';
                    input.value = divisionId;

                    // Append input element to form
                    form.appendChild(input);

                    // Append form to document body and submit it
                    document.body.appendChild(form);
                    form.submit();
                }
            });
        });
    });
});
