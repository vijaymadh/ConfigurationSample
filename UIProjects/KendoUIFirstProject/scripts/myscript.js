$(function () {

    var team = [
            { text: "Amit Pawar", value: "<span>@Amit Pawar </span>" },
            { text: "Deepak Pardeshi", value: "<span style='color:blue;'>@Deepak Pardeshi </span>" },
            { text: "Laxman Jadhav", value: "<span style='color:blue;'>@Laxman Jadhav </span>" },
            { text: "Sanjay Kale", value: "<span style='color:blue;'>@Sanjay Kale </span>" }
    ];

    $('#editor').textComplete
    $('#editor').kendoEditor({
        tools: [
            "bold", "italic", "underline", "strikethrough",
            "insertUnorderedList", "insertOrderedList", "indent",
            "outdent", "createLink", "unlink",
            "subscript", "superscript",
            "createTable", "addRowAbove",
            "justifyLeft",
            "justifyCenter",
            "justifyRight",
            "justifyFull",
            "addRowBelow",
            "addColumnLeft",
            "addColumnRight",
            "deleteRow",
            "deleteColumn",
            "viewHtml",
            "formatting",
            "fontName",
            "fontSize",
            "foreColor",
            "backColor",
            "insertHtml"
        ],
        insertHtml: team,
        //[
        //    { text: "Amit Pawar", value: "<span style='color:blue;'>@Amit Pawar </span>" },
        //    { text: "Deepak Pardeshi", value: "<span style='color:blue;'>@Deepak Pardeshi </span>" },
        //    { text: "Laxman Jadhav", value: "<span style='color:blue;'>@Laxman Jadhav </span>" },
        //    { text: "Sanjay Kale", value: "<span style='color:blue;'>@Sanjay Kale </span>" }
        //],
        messages : {
            insertHtml : "Team"
        },
        select: onSelect,
        execute: onExecute,
        change: onChange
    });

    var editor = $('#editor').data("kendoEditor");

    //var autoComplete = getUserAutocomplete();
    //$(document.body).append(userAutoComplete);
    //editor.exec("insertHtml", { value: "<input>" + $(autoComplete).html() + "</input>" });
    
    // Check if entered character is '@' 
    $(editor.body).on("keypress", function (event) {
        var keycode = event.which || event.keyCode;
        if (keycode == 64) {
            console.log("Key : " + keycode);

            var icmUsersDropDown = getUsersDropdown();
            editor.exec("insertHtml", { value: "<select>" + $(icmUsersDropDown).html() + "</select>" });

            //var autoComplete = getUserAutocomplete();
            //$(editor.body).append(userAutoComplete);
            //editor.exec("insertHtml", { value: icmUsersAutocomplete });
        }
    });

    function onSelect(event) {
        console.log("onSelect : " +  event.sender.getSelection().focusOffset);
    }

    function onExecute(event) {
        console.log("onExecute function called");
    }

    function onChange(event) {
        console.log("onChange function called");
    }

    function getUsersDropdown() {
        var users = [
             { val: 1, text: 'Amit Pawar' },
             { val: 2, text: 'Deepak Pardeshi' },
             { val: 3, text: 'Laxman Jadhav' },
             { val: 4, text: 'Sanjay Kale' }
        ];

        var dropDown = $('<datalist>');

        $(users).each(function () {
            dropDown.append($("<option>").attr('value', this.val).text(this.text));
        });


        $(document).on("focus", ".icmUserDropDown", function () {
            dropDownValue = $(this).val();
            alert("focus" + dropDownValue);
        });

        $(document).on("blur", ".icmUserDropDown", function () {
            dropDownValue = $(this).val();
            alert("blur" + dropDownValue);
        });

        $(document).on("change", ".icmUserDropDown", function () {
            dropDownValue = $(this).val();
            alert("change" + dropDownValue);
        });

        return dropDown;
    }

    function getUserAutocomplete() {
        var users = ["Amit Pawar",
            "Deepak Pardeshi",
            "Laxman Jadhav",
            "Sanjay Kale"
        ];

        var autoCompleteTextBox = $('<input id="autocomplete" />');
        var autoComplete = $("#autoComplete").kendoAutoComplete({
            dataSource: users,
            autoWidth: true,
        });
        //var autoComplete = $("#autocomplete").data("kendoAutoComplete");

        return autoComplete;
    }

});