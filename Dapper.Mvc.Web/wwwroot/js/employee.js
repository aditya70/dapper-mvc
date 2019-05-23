
$(document).ready(function () {

    // Set up the DataTable grid
    $('#serverTable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        pageLength: 5,
        lengthMenu: [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]]
        //buttons: [
        //    'copy', 'csv', 'excel', 'pdf', 'print'
        //]
     //   "order": [[2, "desc"]]
    });

});