document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.deleteButton').forEach(button => {
        button.addEventListener('click', function () {
            const value = this.getAttribute('data-value'); // Get the value dynamically (can be string or int)
            const deleteUrl = this.getAttribute('data-delete-url'); // Get the delete URL dynamically
            const paramName = this.getAttribute('data-param-name') || 'id'; // Get the parameter name dynamically, default to 'id'

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

                    // Create input element for the parameter
                    const input = document.createElement('input');
                    input.type = 'hidden';
                    input.name = paramName; // Set the parameter name dynamically
                    input.value = value; // Set the value dynamically (can be string or int)

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
