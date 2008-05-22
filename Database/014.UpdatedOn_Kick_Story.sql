use DotNetKicks
go

/* column to story to indicate when this was last updated, used
to generate an increment update of the lucene index for searching */
alter table  Kick_Story
add UpdatedOn DateTime not null default(getDate())
go


/* add the default values required for the lucene search */ 
insert into kick_setting ([name], [value]) values ('Search.Lucene.BaseDirectory', '~/App_Data/StoryIndex')
insert into kick_setting ([name], [value]) values ('Search.Lucene.ReindexInterval', '10')

