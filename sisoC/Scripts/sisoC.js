$(document).ready(function () {
    $("#StateID").change(function () {
        $("#CityID").empty();
        $("#CityID").append('<option value="0">[Seleccionar...]</option>');
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { stateId: $("#StateID").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#CityID").append('<option value="'
                        + data.CityID + '">'
                        + data.Name + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve cities.' + ex);
            }
        });
        return false;
    });
});
