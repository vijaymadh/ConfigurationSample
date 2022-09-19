
function GetTableHeader(smartLinkModel, attributeList) {
    var headerRow = "<tr>";
    headerRow = headerRow + "<th></th>";
    var fields = JSON.parse(smartLinkModel.fields);

    for (var i = 0; i < fields.length; i++) {
        var field = jQuery.map(attributeList, function (obj) {
            if (obj.field === fields[i])
                return obj; // or return obj.name, whatever.
        });

        if (field[0] != null || field[0] != undefined) {
            headerRow = headerRow + "<th>" + field[0].text + "</th>";
        }
    }

    headerRow = headerRow + "</tr>";
    return headerRow;
}

function lowerFirstLetter(string) {
    return string.charAt(0).toLowerCase() + string.slice(1);
}

function GetTableData(smartLinkModel, rowArray, attributeList) {
    var rowData = "<tr>";
    var fields = JSON.parse(smartLinkModel.fields);
    for (var i = 0; i < rowArray.length; i++) {
        rowData = rowData + "<td><a href='/Agreement/Details?entityName=" + rowArray[i].entityName + "&id=" + rowArray[i].sysId + "' target='_blank'><span class='grid_details'></span></a></td>";
        for (var j = 0; j < fields.length; j++) {
            var field = jQuery.map(attributeList, function (obj) {
                if (obj.field === fields[j])
                    return obj; // or return obj.name, whatever.
            });

            if (field[0] != null || field[0] != undefined) {
                rowData = rowData + "<td>";
                if (typeof rowArray[i][lowerFirstLetter(fields[j])] != 'undefined') {
                    rowData = rowData + unescape(rowArray[i][lowerFirstLetter(fields[j])]);
                }
                else {
                    rowData = rowData + "";
                }

                rowData = rowData + "</td>";
            }
        }
        rowData = rowData + "</tr>";
    }
    return rowData;
}

