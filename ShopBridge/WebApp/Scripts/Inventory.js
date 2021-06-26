//Javascript will call the API and Send data to  MVC view
//Method will be used to call the Existing Inventory data from the API
function LoadingInventory()
{
    $("#ItemInvData").html(`
          <table class="table table-bordered table-sm datatable" id="inventory_existing_data">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Entry Date</th>
                    <th>Description</th>
                    <th>Qty Available</th>
                    <th>Price (Total)</th>
                    <th>In Stock</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody id="Inventory_table_tbody">

         </tbody>
        </table>
    `);
    $.get("../api/inventoryapi", function (response) {
        response.map((item) => {
            $("#Inventory_table_tbody").append(
                ` <tr>
                    <td>${item.item_name}</td>
                    <td class="text-center"><span class="d-none">${item.SortingDate}</span>${item.Entry_Date}</td>
                    <td class="text-center">${item.Description}</td>
                    <td class="text-center">${item.Qty}</td>
                     <td class="text-center">${item.price}</td>
                    <td class="text-center">${item.InStock}</td>
                     <td class="text-center">${item.deleted}</td>
                    <td class="text-center">
                        <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-gear" viewBox="0 0 16 16">
                          <path d="M8 4.754a3.246 3.246 0 1 0 0 6.492 3.246 3.246 0 0 0 0-6.492zM5.754 8a2.246 2.246 0 1 1 4.492 0 2.246 2.246 0 0 1-4.492 0z"/>
                          <path d="M9.796 1.343c-.527-1.79-3.065-1.79-3.592 0l-.094.319a.873.873 0 0 1-1.255.52l-.292-.16c-1.64-.892-3.433.902-2.54 2.541l.159.292a.873.873 0 0 1-.52 1.255l-.319.094c-1.79.527-1.79 3.065 0 3.592l.319.094a.873.873 0 0 1 .52 1.255l-.16.292c-.892 1.64.901 3.434 2.541 2.54l.292-.159a.873.873 0 0 1 1.255.52l.094.319c.527 1.79 3.065 1.79 3.592 0l.094-.319a.873.873 0 0 1 1.255-.52l.292.16c1.64.893 3.434-.902 2.54-2.541l-.159-.292a.873.873 0 0 1 .52-1.255l.319-.094c1.79-.527 1.79-3.065 0-3.592l-.319-.094a.873.873 0 0 1-.52-1.255l.16-.292c.893-1.64-.902-3.433-2.541-2.54l-.292.159a.873.873 0 0 1-1.255-.52l-.094-.319zm-2.633.283c.246-.835 1.428-.835 1.674 0l.094.319a1.873 1.873 0 0 0 2.693 1.115l.291-.16c.764-.415 1.6.42 1.184 1.185l-.159.292a1.873 1.873 0 0 0 1.116 2.692l.318.094c.835.246.835 1.428 0 1.674l-.319.094a1.873 1.873 0 0 0-1.115 2.693l.16.291c.415.764-.42 1.6-1.185 1.184l-.291-.159a1.873 1.873 0 0 0-2.693 1.116l-.094.318c-.246.835-1.428.835-1.674 0l-.094-.319a1.873 1.873 0 0 0-2.692-1.115l-.292.16c-.764.415-1.6-.42-1.184-1.185l.159-.291A1.873 1.873 0 0 0 1.945 8.93l-.319-.094c-.835-.246-.835-1.428 0-1.674l.319-.094A1.873 1.873 0 0 0 3.06 4.377l-.16-.292c-.415-.764.42-1.6 1.185-1.184l.292.159a1.873 1.873 0 0 0 2.692-1.115l.094-.319z"/>
                        </svg>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="javascript:;" onclick="EditInventory(${item.Id})">Edit</a>
                            <a class="dropdown-item" href="javascript:;" onclick="RemoveInventory(${item.Id})">Delete</a>
                           
                        </div>
                    </div>
                    </td>
                </tr>`
            );
        });
        $("#inventory_existing_data").DataTable();
           
    });
}

//function for opening form for inserting inventory form
function AddInventory()
{
    $("#inventoryModal").modal("show");
}
///Function will be used to sve data into the database
function SaveData()
{
    $(".mandatory").removeClass("border-danger");

    DisableButton();
    //checking for validation before submitting
    var validation = true;
    $(".mandatory").each(function () {
        if (!$(this).val().trim()) {
            $(this).addClass("border-danger");
            validation = false;
        }

    });
  
    //check for validation
    if (!validation) {
        EnableButton();
        return false;
    }
    var inventoryItem = {
       
        Name: $("#item_name").val(),
        Price: $("#price").val(),
        Quantity: $("#itemQuantity").val(),
        Description: $("#Description").val(),
        Is_Active: $("#Is_Active").is(":checked"),
        Id: $("#hid_Id").val()
    }
    //send data to api for saving object
    $.post('../api/inventoryapi', inventoryItem, function (data) {
        if (data == "Okay") {
          
            if ($("#hid_Id").val() > 0) {
                $(".message").html(`<span class="text-success">Record updated successfully</span>`);
              
            }
            else {
                $(".message").html(`<span class="text-success">Record inserted successfully</span>`);
            }
           
        }
        else {
            $(".message").html(`<span class="text-danger">There is some error in system. Please try again</span>`);
        }
        LoadingInventory();
        EnableButton();
        ResetForm();
        $("#inventoryModal").modal("hide");
        
    });

}
//Edit Item Inventory
function EditInventory(Id) {

    $.get(`../api/inventoryapi/${Id}`, function (data) {
      
        if (data) {
            AddInventory();
            $("#item_name").val(data.Name);
            $("#price").val(data.Price);
            $("#itemQuantity").val(data.Quantity);
            $("#Description").val(data.Description);
            $("#Is_Active").prop("checked", data.Is_Active);
            $("#hid_Id").val(data.Id);
        }
        
        
    });
}
//Remove Intem from inventory
function RemoveInventory(Id)
{
    var TriggeredObj = $(event.target).closest("tr");
    if (confirm("Are you sure want to delete this item?")) {
        $.ajax({
            url: "/api/inventoryapi/" + Id,
            type: "DELETE",
            dataType: "json",
            success: function (data, statusText) {
                if (data == "Okay")
                {
                    $(TriggeredObj).remove();
                }
            },
            error: function (request, textStatus, error) {

            }
        });
    }
    
    
}


//function which will enable submitting data. Process will used to stop to for multiple submission.
function EnableButton() {
    $("#SubmitButton").replaceWith(`<button type="button" id="SubmitButton" class="btn btn-primary" onclick="SaveData(this);">Submit</button>`)
}

function DisableButton() {
    $("#SubmitButton").replaceWith(`<button  id="SubmitButton" disabled class="btn btn-primary" type="button" disabled>
  <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
  Sending...
</button>`);
}
//to Reset Data
function ResetForm()
{
    $("#inventoryModal").find("input,textarea,hidden").val("");
    $("#inventoryModal").find("input:checkbox").prop("checked", false)
}

