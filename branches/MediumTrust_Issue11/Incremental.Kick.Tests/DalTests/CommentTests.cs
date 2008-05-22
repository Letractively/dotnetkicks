using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;
using Incremental.Kick.BusinessLogic;
using MbUnit.Framework;
using System.Security;

namespace Incremental.Kick.Tests.DalTests {
    [TestFixture]
    public class CommentTests : DalTest {

        //[Test, RollBack2]
        //public void AddCommentIncrementsStoryCommentCount() {
        //    Assert.AreEqual(_story.CommentCount, 20);
        //    Comment.CreateComment(_host.HostID, _story.StoryID, _normalUser, "This is a comment from a normal user");
        //    Story updatedStory = Story.FetchStoryByIdentifier("Story_with_20_comments");
        //    Assert.AreEqual(updatedStory.CommentCount, 21);
        //}

        //[Test, ExpectedException(typeof(SecurityException)), RollBack2]
        //public void SecurityExceptionIsThrownIfBannedUserPostsAComment() {
        //    Comment.CreateComment(_host.HostID, _story.StoryID, _bannedUser, "This is a comment from a banned user");
        //}
    }
}
