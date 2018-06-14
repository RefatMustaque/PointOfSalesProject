$(document).ready(function () {

    ﻿
    //to load Employee accoring to branch
    $("#BranchId").change(function () {
        var branId = $("#BranchId").val();
        var jsonData = { branchId: branId }
        $.ajax({
            url: "/EmployeeInfo/GetByBranch",
            data: jsonData,
            type: "post",
            //contentType: "application/json",
            success: function (response) {
                var employeeDD = $("#EmployeeInfoId");
                employeeDD.empty();
                var option = "<option value>Select . . .</option>";

                $.each(response, function (key, employee) {
                    option += "<option value='" + employee.Id + "'>" + employee.Name + "</option>";

                });
                employeeDD.append(option);
            },
            error: function (response) { }
        });



    });

     

    //to add element to purchase detail table    
    $("#addButton").click(function () {
        var selectedItem = getSelectedItem();
        createRowForPurchaseDetails(selectedItem);
        creatGrandTotal(selectedItem);

        $("#Item").val("");
        $("#Quantity").val("");
        $("#PurchasePrice").val("");
    });

    var GrandTotal = 0;

    function creatGrandTotal(selectedItem) {
        GrandTotal = GrandTotal + selectedItem.LiveTotal;
        var GrandTotalColumn = "<td><input type='hidden' for='PurchaseTotalAmount' id='PurchaseTotalAmount' name='PurchaseTotalAmount' value='" + GrandTotal + "'/>" + GrandTotal + "</td><td></td>";
        $("#grandTotal").html(GrandTotalColumn);
     }

     
    function createRowForPurchaseDetails(selectedItem) {
        index = $("#purchaseTable").children("tr").length + 1;

        var IndexCell = "<td><input type='hidden' name='PurchaseReceivingDetailses.Index' value='" + index + "'/>" + index + "</td>"
        var Item = "<td><input type='hidden' name='PurchaseReceivingDetailses[" + index + "].ItemId' value='" + selectedItem.ItemId + "'/>" + selectedItem.ItemName + "</td>"
        var Quantity = "<td><input type='hidden' name='PurchaseReceivingDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "'/>" + selectedItem.Quantity + "</td>"
        var Price = "<td><input type='hidden' name='PurchaseReceivingDetailses[" + index + "].PurchasePrice' value='" + selectedItem.Price + "'/>" + selectedItem.Price + "</td>"
        var LiveTotal = "<td><input type='hidden' name='PurchaseReceivingDetailses[" + index + "].PurchaseItemTotalPrice' value='" + selectedItem.LiveTotal + "'/>" + selectedItem.LiveTotal + "</td>"
        var ActionLink = "<td class='row'><button type='button' class='btn btn-primary btn-xs glyphicon glyphicon-edit col-md-4 col-md-offset-1'></button><button id='" +index+ "' type='button' class='btn btn-danger btn-xs glyphicon glyphicon-trash col-md-4 col-md-offset-2'></button></td>"

        var row = "<tr id='purchaseReceivingDetails" + index + "'>" + IndexCell + Item + Quantity + Price + LiveTotal + ActionLink + "</tr>";

        $("#purchaseTable").append(row);
    }

    function getSelectedItem() {
        var ItemId = $("#Item").val();
        var ItemName = $("#Item option:selected").text();
        var Quantity = $("#Quantity").val();
        var Price = $("#PurchasePrice").val();
        var LiveTotal = $("#PurchasePrice").val() * $("#Quantity").val();

        var model = {
            "ItemId": ItemId,
            "ItemName": ItemName,
            "Quantity": Quantity,
            "Price": Price,
            "LiveTotal": LiveTotal,
        };
        return model;
    }


    //table delete button
    $("table").on("click", ".btn-danger", function () {
        $(this).closest('tr').remove();

    })

});