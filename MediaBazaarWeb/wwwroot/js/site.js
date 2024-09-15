// Function to handle datepicker change event
document.getElementById("datepicker").addEventListener("change", function () {
    var selectedDate = new Date(this.value);
    var personId = document.getElementById("personId").value;
    $.ajax({
        type: "POST",
        url: "/Schedule?handler=OnPostCheckAvailability",
        data: { personId: 2, date: "2024-04-14" },
        success: function (response) {
            // Update radio buttons based on availability
            updateRadioButtons(response);
        },
        error: function () {
            console.error("Error checking availability.");
        }
    });
});

// Function to update radio buttons based on availability
function updateRadioButtons(availability) {
    // Reset all radio buttons
    document.querySelectorAll('input[name="availability"]').forEach(function (radio) {
        radio.checked = false;
    });

    // Update radio buttons based on availability
    switch (availability) {
        case "FirstShift":
            document.getElementById("morning").checked = true;
            break;
        case "SecondShift":
            document.getElementById("afternoon").checked = true;
            break;
        case "ThirdShift":
            document.getElementById("evening").checked = true;
            break;
        default:
            document.getElementById("unavailable").checked = true;
            break;
    }
}
