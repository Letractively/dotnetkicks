var linkToSelect;
var PopularStoryNavigator_CSS_LINK_CLASS = "PopularStoryHeaderLink";
var PopularStoryNavigator_CSS_LINK_SELECTED_CLASS = "PopularStoryHeaderLinkSelected";
var PopularStoryNavigator_CSS_LINK_CHANGING_CLASS = "PopularStoryHeaderLinkChanging";
var PopularStoryNavigator_CSS_LINK_CHANGING_SELECTED_CLASS = "PopularStoryHeaderLinkChangingSelected";

PopularStoryNavigator_Initialise();

function PopularStoryNavigator_Initialise() {
    dojo.event.topic.subscribe("GetPopularStories_End", dj_global, "PopularStoryHeader_GetPopularStories_End");  
}

function PopularStoryHeader_GetPopularStories(sortBy, link) {
    dojo.event.topic.publish("GetPopularStories", sortBy, 1);
    PopularStoryHeader_SetChangingLinkStyle();
    AddCssClass(link, PopularStoryNavigator_CSS_LINK_CHANGING_SELECTED_CLASS);
    linkToSelect = link;
}

function PopularStoryHeader_GetPopularStories_End() {
    PopularStoryHeader_ClearLinkStyle();
    AddCssClass(linkToSelect, PopularStoryNavigator_CSS_LINK_SELECTED_CLASS);
    linkToSelect = null;
}

function PopularStoryHeader_SetChangingLinkStyle() {
    PopularStoryHeader_ClearLinkStyle();
    
    var links = PopularStoryHeader_GetLinks();
    for (i=0; i<links.length; i++) {
        AddCssClass(links[i], PopularStoryNavigator_CSS_LINK_CHANGING_CLASS);
    }
}

function PopularStoryHeader_ClearLinkStyle() {
    var links = PopularStoryHeader_GetLinks();
    
    for (i=0; i<links.length; i++) {
        SwitchCssClass(links[i], PopularStoryNavigator_CSS_LINK_SELECTED_CLASS, "");
        SwitchCssClass(links[i], PopularStoryNavigator_CSS_LINK_CHANGING_CLASS, "");
        links[i].blur();
    }
}

var allLinks;
function PopularStoryHeader_GetLinks() {
    if(allLinks == null) {
        allLinks = getElementsByClass(PopularStoryNavigator_CSS_LINK_CLASS, null, null);
    }
    
    return allLinks;
}