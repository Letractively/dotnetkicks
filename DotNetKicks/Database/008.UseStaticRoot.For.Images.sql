--SQL file UseStaticRoot
--==============================================
--Allows a site to use  static root for images or have them as a folder under root
 
--Issue Number 49

--Build Number xyz
 

ALTER TABLE [dbo].[Kick_Host] ADD [UseStaticRoot] [bit] NULL
