function showConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmationModal')).show();
}

function hideConfirmationModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmationModal')).hide();
}