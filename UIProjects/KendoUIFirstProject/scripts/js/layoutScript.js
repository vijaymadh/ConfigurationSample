$(document).ready(function () {
    $('.searchbar-toggle').click(function (e) {
        toggleFilterPane();
    }).dblclick(function (ev) {
        return;
    });
});

function resizeSearchGrid(height) {
    //The dirty way
    var isSearchScreen = $('#grid-container');
    if (isSearchScreen.length == 0) return;
    var searchGrid = $('#grid'),
        noncontent = searchGrid.children().not('.k-grid-content'),
        noncontentHeight = 0;

    noncontent.each(function () {
        noncontentHeight += $(this).outerHeight();
    });

    searchGrid.children('.k-grid-content').height(height);
    searchGrid.height(height + noncontentHeight);
}

function toggleFilterPane() {
    //$('#filterPane').toggle();
    //$('#left-pane-container').toggle();

    if ($('#filterPane').length > 0) {
        applyCSSChangesForSearchWindow();
    } else if ($('#left-pane-container').length > 0) {
        applyCSSChangesForIndexSearch();
    }
}

function applyCSSChangesForSearchWindow() {
    if ($('#toggleBtn_Search_Div').hasClass('toggleBtn_Search_Expand')) { // hide logic
        hideSearchWindowSearchPanel();
    } else { // show logic
        showSearchWindowSearchPanel();
    }
}

function showSearchWindowSearchPanel() {
    if ($('#toggleBtn_Search_Div').hasClass('toggleBtn_Search_Collapse')) {
        $('#toggleBtn_Search_Div').removeClass('toggleBtn_Search_Collapse');
        $('#toggleBtn_Search_Div').addClass('toggleBtn_Search_Expand');
    }
    $("#filterPane").show("slide", { direction: "left" }, 10);
    $(".searchbar-toggle > img").removeClass("togglebtn-rotate");
    $(".Pagination-fix").removeClass("searchgrid-width");
    $("#searchImageBody").removeClass("searchgrid-width");
    $('#searchContent').removeClass('searchgrid-width');
    $("#searchImageBody").addClass("searchimagebody-width");
    $(".searchbar-toggle > img").attr("title", "Hide left panel");
    //$('#filterPane').removeClass("hide").addClass("show");
}

function hideSearchWindowSearchPanel() {
    if ($('#toggleBtn_Search_Div').hasClass('toggleBtn_Search_Expand')) {
        $('#toggleBtn_Search_Div').removeClass('toggleBtn_Search_Expand');
        $('#toggleBtn_Search_Div').addClass('toggleBtn_Search_Collapse');
    }
    $("#filterPane").hide("slide", { direction: "left" }, 10);
    $(".searchbar-toggle > img").addClass("togglebtn-rotate");
    $(".Pagination-fix").addClass("searchgrid-width");
    $("#searchImageBody").addClass("searchgrid-width");
    $('#searchContent').addClass('searchgrid-width');
    $("#searchImageBody").removeClass("searchimagebody-width");
    $(".searchbar-toggle > img").attr("title", "Show left panel");
    //$('#filterPane').removeClass("show").addClass("hide");
}

function persistSearchPanelState() {
    if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Expand')) { // show logic
        showSearchWindowSearchPanel();
    } else if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Collapse')) { // hide logic
        hideSearchWindowSearchPanel();
    }
}

function applyCSSChangesForIndexSearch() {
    if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Expand')) { // hide logic
        hideListPageSearchPanel();
    } else if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Collapse')) { // show logic
        showListPageSearchPanel();
    }
}

function hideListPageSearchPanel() {
    if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Expand')) {
        $('#toggleBtn_List_Div').removeClass('toggleBtn_List_Expand');
        $('#toggleBtn_List_Div').addClass('toggleBtn_List_Collapse');
    }
    $("#left-pane-container").hide("slide", { direction: "left" }, 10);
    $(".searchbar-toggle > img").addClass("togglebtn-rotate");
    $("#search-pane").addClass("searchgrid-width");
    $("#searchImageBody").addClass("searchgrid-width");
    $('#searchContent').addClass('searchgrid-width');
    $("#searchImageBody").removeClass("searchimagebody-width");
    $(".searchbar-toggle > img").attr("title", "Show left panel");
}

function showListPageSearchPanel() {
    if ($('#toggleBtn_List_Div').hasClass('toggleBtn_List_Collapse')) {
        $('#toggleBtn_List_Div').removeClass('toggleBtn_List_Collapse');
        $('#toggleBtn_List_Div').addClass('toggleBtn_List_Expand');
    }
    $("#left-pane-container").show("slide", { direction: "left" }, 10);
    $(".searchbar-toggle > img").removeClass("togglebtn-rotate");
    $("#search-pane").removeClass("searchgrid-width");
    $('#searchContent').removeClass('searchgrid-width');
    $("#searchImageBody").removeClass("searchgrid-width");
    $("#searchImageBody").addClass("searchimagebody-width");
    $(".searchbar-toggle > img").attr("title", "Hide left panel");
}

function checkStorageValues() {    
    switch (window.location.pathname.toLocaleLowerCase()) {
        case '/contractrequest/details':
        case '/contractrequest/details/':
            setlocalStorageValue('ContractRequestIndex', 'request');
            break;
        case '/agreement/create':
        case '/agreement/create/':
            setlocalStorageValue('AgreementsCreate', 'agreement');
            break;
        case '/metadata/attributeindex':
            setlocalStorageValue('firstChild', 'setup');
            break;
        case '/search/list/agreement':
            setlocalStorageValue('firstChild', 'agreement');
            break;
        case '/search/list/sourcing':
            setlocalStorageValue('firstChild', 'sourcingdashboard');
            break;
        case '/search/list/template':
            setlocalStorageValue('firstChild', 'template');
            break;
        case '/search/list/clause':
            setlocalStorageValue('firstChild', 'clause');
            break;
        case '/search/list/contracttype':
            setlocalStorageValue('firstChild', 'contract');
            break;
        case '/search/list/masterdata':
            setlocalStorageValue('firstChild', 'masterdata');
            break;
        case '/search/list/userinformation':
            setlocalStorageValue('firstChild', 'userinformation');
            break;
        case '/search/list/distributiongroup':
            setlocalStorageValue('firstChild', 'distributiongroup');
            break;
        case '/search/list/securitygroup':
            setlocalStorageValue('firstChild', 'securitygroup');
            break;
        case '/organization/details':
            setlocalStorageValue('firstChild', 'admin');
            break;
        case '/notification/category':
            setlocalStorageValue('firstChild', 'notification');
            break;
        case '/search/list/orggroup':
            setlocalStorageValue('firstChild', 'orggroup');
            break;
        case '/search/list/contractrequest':
            setlocalStorageValue('firstChild', 'request');
            break;
        case '/search/list/currency':
            setlocalStorageValue('firstChild', 'currency');
            break;
        case '/search/list/reasonmaster':
            setlocalStorageValue('firstChild', 'reasonmaster');
            break;
    }
    if (!window.sessionStorage.clickElement || window.sessionStorage.clickElement == 'undefined'
        || !window.sessionStorage.parent || window.sessionStorage.parent == 'undefined') {
        setlocalStorageValue('dashboard', 'root');
        return;
    }

}

function ChangeTabClass(seleetedTab, parenElem) {    
    $("#_menu a li").removeAttr("class");
    $("#" + seleetedTab).attr("class", 'active');

    showChild(seleetedTab, parenElem);

    $("#customUserMenu").show();
}

function showChild(elem, parenElem) {
    window.sessionStorage.setItem("parent", parenElem);
    window.sessionStorage.setItem("clickElement", elem);
    $("#" + elem).parent().show();

    $("#" + elem).parent().siblings().each(function () {
        if ($(this).attr("parent") == window.sessionStorage.parent) {

            $(this).show();
        }
    });
}

function setlocalStorageValue(elem, parenElem) {
    if (elem == "firstChild") {
        elem = $("a[parent=" + parenElem + "]").filter(":first").next().children("li").attr("id");
    }

    if (elem == "search") {
        parenElem = window.sessionStorage.getItem("parent");
        elem = window.sessionStorage.getItem("clickElement");
    }

    window.sessionStorage.setItem("parent", parenElem);
    window.sessionStorage.setItem("clickElement", elem);
}

function closeErrorMessage() {
    $("#ErrorMessage").slideUp();
    $("#pagination").remove();
}