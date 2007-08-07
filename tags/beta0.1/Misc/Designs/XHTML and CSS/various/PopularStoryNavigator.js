PopularStoryNavigator_Initialise();

function PopularStoryNavigator_Initialise() {
    dojo.event.topic.subscribe("GetPopularStories", dj_global, "PopularStoryNavigator_GetPopularStories");  
}

function PopularStoryNavigator_GetPopularStories(sortBy, pageNumber) {
    Ajax_GetPopularStories(sortBy, pageNumber, PopularStoryNavigator_GetPopularStories_End, Failure); 
}

function PopularStoryNavigator_GetPopularStories_End(storyListHtml) {
    PopularStoryNavigator_GetPopularStoryListDiv().innerHTML = storyListHtml;
   
    dojo.event.topic.publish("GetPopularStories_End");
    FinishLoading();
}

function PopularStoryNavigator_GetPopularStoryListDiv() { return document.getElementById("PopularStoryListDiv"); }
