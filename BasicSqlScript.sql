/*
代码生成器 V 1.8.1.1 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/

--表开始
GO
CREATE TABLE [dbo].[SMenu]([MenuID] [int] IDENTITY(1,1) NOT NULL,
[ParentID] [int] NULL CONSTRAINT [DF_SMenu_ParentID]  DEFAULT ((0)),
[Title] [nvarchar](max) NULL CONSTRAINT [DF_SMenu_Title]  DEFAULT (' '),
[Icon] [nvarchar](max) NULL CONSTRAINT [DF_SMenu_Icon]  DEFAULT (' '),
[Link] [nvarchar](max) NULL CONSTRAINT [DF_SMenu_Link]  DEFAULT (' '),
[Sort] [int] NULL CONSTRAINT [DF_SMenu_Sort]  DEFAULT ((0)),
[Behavior] [nvarchar](max) NULL CONSTRAINT [DF_SMenu_Behavior]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_SMenu_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_SMenu_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_SMenu_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_SMenu_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_SMenu_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_SMenu] PRIMARY KEY CLUSTERED (MenuID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'MenuID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Link'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行为' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Behavior'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SMenu', @level2type=N'COLUMN',@level2name=N'Remark'
--表开始
GO
CREATE TABLE [dbo].[SRole]([RoleID] [int] IDENTITY(1,1) NOT NULL,
[RoleName] [nvarchar](max) NULL CONSTRAINT [DF_SRole_RoleName]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_SRole_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_SRole_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_SRole_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_SRole_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_SRole_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_SRole] PRIMARY KEY CLUSTERED (RoleID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRole', @level2type=N'COLUMN',@level2name=N'Remark'
--表开始
GO
CREATE TABLE [dbo].[SRoleDetail]([RoleDetailID] [int] IDENTITY(1,1) NOT NULL,
[RoleID] [int] NULL CONSTRAINT [DF_SRoleDetail_RoleID]  DEFAULT ((0)),
[MenuID] [int] NULL CONSTRAINT [DF_SRoleDetail_MenuID]  DEFAULT ((0)),
[Behavior] [nvarchar](max) NULL CONSTRAINT [DF_SRoleDetail_Behavior]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_SRoleDetail_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_SRoleDetail_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_SRoleDetail_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_SRoleDetail_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_SRoleDetail_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_SRoleDetail] PRIMARY KEY CLUSTERED (RoleDetailID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色明细ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'RoleDetailID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'MenuID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行为' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'Behavior'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SRoleDetail', @level2type=N'COLUMN',@level2name=N'Remark'
--表开始
GO
CREATE TABLE [dbo].[SUser]([UserID] [int] IDENTITY(1,1) NOT NULL,
[RoleID] [int] NULL CONSTRAINT [DF_SUser_RoleID]  DEFAULT ((0)),
[UserName] [nvarchar](max) NULL CONSTRAINT [DF_SUser_UserName]  DEFAULT (' '),
[Accounts] [nvarchar](max) NULL CONSTRAINT [DF_SUser_Accounts]  DEFAULT (' '),
[Password] [nvarchar](max) NULL CONSTRAINT [DF_SUser_Password]  DEFAULT (' '),
[Single] [bit] NULL CONSTRAINT [DF_SUser_Single]  DEFAULT ((0)),
[Verify] [nvarchar](max) NULL CONSTRAINT [DF_SUser_Verify]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_SUser_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_SUser_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_SUser_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_SUser_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_SUser_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_SUser] PRIMARY KEY CLUSTERED (UserID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Accounts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单点登录状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Single'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'校验码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Verify'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUser', @level2type=N'COLUMN',@level2name=N'Remark'
--表开始
GO
CREATE TABLE [dbo].[SLog]([LogID] [int] IDENTITY(1,1) NOT NULL,
[UserID] [int] NULL CONSTRAINT [DF_SLog_UserID]  DEFAULT ((0)),
[UserIP] [nvarchar](max) NULL CONSTRAINT [DF_SLog_UserIP]  DEFAULT (' '),
[RequestPath] [nvarchar](max) NULL CONSTRAINT [DF_SLog_RequestPath]  DEFAULT (' '),
[Controller] [nvarchar](max) NULL CONSTRAINT [DF_SLog_Controller]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_SLog_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_SLog_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_SLog_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_SLog_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_SLog_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_SLog] PRIMARY KEY CLUSTERED (LogID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'LogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'UserIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'RequestPath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作控制器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'Controller'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SLog', @level2type=N'COLUMN',@level2name=N'Remark'

GO
SET IDENTITY_INSERT [dbo].[SMenu] ON 
INSERT [dbo].[SMenu] ([MenuID], [ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (1, 0, N'系统设置', N'fa fa-gear', N' ', 999, N'show')
INSERT [dbo].[SMenu] ([MenuID], [ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (2, 1, N'用户管理', N'fa fa-user', N'/User', 1, N'index,inquire,insert,update,delete,print')
INSERT [dbo].[SMenu] ([MenuID], [ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (3, 1, N'角色管理', N'fa fa-users', N'/Role', 2, N'index,inquire,insert,update,delete,print')
INSERT [dbo].[SMenu] ([MenuID], [ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (4, 1, N'系统日志', N'fa fa-leaf', N'/Log', 3, N'index,inquire,delete,print')
SET IDENTITY_INSERT [dbo].[SMenu] OFF

SET IDENTITY_INSERT [dbo].[SRole] ON 
INSERT [dbo].[SRole] ([RoleID], [RoleName]) VALUES (1, N'超级管理员')
INSERT [dbo].[SRole] ([RoleID], [RoleName]) VALUES (2, N'普通管理员')
SET IDENTITY_INSERT [dbo].[SRole] OFF

SET IDENTITY_INSERT [dbo].[SRoleDetail] ON 
INSERT [dbo].[SRoleDetail] ([RoleDetailID], [RoleID], [MenuID], [Behavior]) VALUES (1, 1, 1, N'show')
INSERT [dbo].[SRoleDetail] ([RoleDetailID], [RoleID], [MenuID], [Behavior]) VALUES (2, 1, 2, N'index,inquire,insert,update,delete,print')
INSERT [dbo].[SRoleDetail] ([RoleDetailID], [RoleID], [MenuID], [Behavior]) VALUES (3, 1, 3, N'index,inquire,insert,update,delete,print')
INSERT [dbo].[SRoleDetail] ([RoleDetailID], [RoleID], [MenuID], [Behavior]) VALUES (4, 1, 4, N'index,inquire,delete,print')
SET IDENTITY_INSERT [dbo].[SRoleDetail] OFF

SET IDENTITY_INSERT [dbo].[SUser] ON 
INSERT [dbo].[SUser] ([UserID], [RoleID], [UserName], [Accounts], [Password], [Single], [Verify]) VALUES (1, 1, N'Admin', N'admin', N'a81e2425f5b76a419a97ced421b23852', 1, N'804vfpkfyj')
SET IDENTITY_INSERT [dbo].[SUser] OFF
GO
--==>AdminManage存储进程
CREATE PROCEDURE [dbo].[AdminManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@UserID int = null,--用户ID
@RoleID int = null,--角色ID
@Verify nvarchar(max) = null,--校验码
@Accounts nvarchar(max) = null,--用户账号
@UserName nvarchar(max) = null,--用户名称
@Password nvarchar(max) = null,--用户密码(旧)
@toPassword nvarchar(max) = null--用户密码(新)

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------
	
	IF @Type = 'InquireLogin'--登录
	BEGIN
		SELECT   UserID, RoleID, UserName, Password, Single
		FROM      SUser
		WHERE IsDelete = 0 AND Accounts = @Accounts
	END

	IF @Type = 'InquireVerify'--查询匹配的校验码
	BEGIN
		SELECT   Verify, Single
		FROM      SUser
		WHERE IsDelete = 0 AND UserID = @UserID
	END

	IF @Type = 'UpdateVerify'--更新匹配的校验码
	BEGIN
		UPDATE  SUser
		SET         Verify = @Verify
		WHERE IsDelete = 0 AND UserID = @UserID
	END
	
	IF @Type = 'InquireMenu'--查询功能菜单
	BEGIN
		SELECT    SRoleDetail.RoleID, SRoleDetail.Behavior AS RBehavior, SMenu.MenuID, SMenu.ParentID, SMenu.Title, SMenu.Behavior AS MBehavior, SMenu.Icon, SMenu.Link, SMenu.Sort
		FROM      SRoleDetail INNER JOIN SMenu ON SRoleDetail.MenuID = SMenu.MenuID
		WHERE   SRoleDetail.IsDelete = 0 AND SMenu.IsDelete = 0 AND SRoleDetail.RoleID = @RoleID
		ORDER BY SMenu.Sort
	END

	IF @Type = 'UpdateUser'--更新个人资料数据
	BEGIN
		UPDATE  SUser
		SET UserName = RTRIM(LTRIM(@UserName)), Password = RTRIM(LTRIM(@toPassword))
		WHERE IsDelete = 0 AND UserID = @UserID AND Password = @Password
	END

END
--==>AdminManage存储进程
GO
--==>UserManage存储进程
CREATE PROCEDURE [dbo].[UserManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@UserID int = null,--用户ID
@RoleID int = null,--角色ID
@Accounts nvarchar(max) = null,--用户账号
@UserName nvarchar(max) = null,--用户名称
@Password nvarchar(max) = null,--用户密码
@Single int = null--单点登陆

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------

	IF @Type = 'InquireUserData'--查询用户数据
	BEGIN
	SELECT @ListCount = COUNT(T.UserID)
	FROM(SELECT SUser.UserID FROM SUser INNER JOIN SRole ON SUser.RoleID = SRole.RoleID WHERE SUser.IsDelete = 0 AND (SUser.CreateTime >= ISNULL(@BeginDate, SUser.CreateTime)) AND (SUser.CreateTime <=ISNULL(@EndDate, SUser.CreateTime)) AND (SUser.UserName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Accounts LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SRole.RoleName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')) T
		--分页查询结果
		SELECT   SUser.UserID, SUser.Accounts, SUser.UserName, SUser.Single, SRole.RoleID, SRole.RoleName, CONVERT(CHAR(20), SUser.CreateTime, 120) AS CreateTime, @ListCount AS tbCount
		FROM      SUser INNER JOIN SRole ON SUser.RoleID = SRole.RoleID
		WHERE SUser.IsDelete = 0 AND (SUser.CreateTime >= ISNULL(@BeginDate, SUser.CreateTime)) AND (SUser.CreateTime <=ISNULL(@EndDate, SUser.CreateTime)) AND (SUser.UserName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Accounts LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SRole.RoleName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')
		ORDER BY CreateTime DESC
		OFFSET (CAST(@Page AS INT) -1) * @PageSize  ROWS FETCH NEXT CAST(@PageSize AS INT) ROWS ONLY
	END
	
	IF @Type = 'InsertUser'--查询该用户是否存在
	BEGIN
		SELECT   UserID
		FROM      SUser
		WHERE Accounts = @Accounts
	END
	
	IF @Type = 'InquireRole'--查询所有角色数据(下拉框绑定)
	BEGIN
		SELECT   SRole.RoleID AS id, SRole.RoleName AS name
		FROM      SRole
		WHERE   SRole.IsDelete = 0
	END
	
	IF @Type = 'InsertUserData'--新增用户数据
	BEGIN
		INSERT INTO SUser(RoleID, UserName, Accounts, Password, Single)
		VALUES   (@RoleID, @UserName, @Accounts, @Password, @Single)
	END
	
	IF @Type = 'UpdateUserData'--更新用户数据
	BEGIN
		IF @Password = ''
		BEGIN
			UPDATE  SUser
			SET         RoleID = @RoleID, UserName = @UserName, Accounts = @Accounts, Single = @Single, Verify = 'zg'
			WHERE IsDelete = 0 AND UserID = @UserID
		END
		ELSE
		BEGIN
			UPDATE  SUser
			SET         RoleID = @RoleID, UserName = @UserName, Accounts = @Accounts, Password = @Password, Single = @Single, Verify = 'zg'
			WHERE IsDelete = 0 AND UserID = @UserID
		END
	END
	
	IF @Type = 'DeleteUserData'--删除用户数据
	BEGIN
		UPDATE  SUser
		SET         IsDelete = 1
		WHERE IsDelete = 0 AND UserID = @UserID
	END

END
--==>UserManage存储进程
GO
--==>RoleManage存储进程
CREATE PROCEDURE [dbo].[RoleManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@RoleID int = null,--角色ID
@MenuID int = null,--菜单ID
@RoleName nvarchar(max) = null,--角色名称
@Behavior nvarchar(max) = null--拥有权限

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------
	
	IF @Type = 'InquireRole'--查询所有角色数据
	BEGIN
		SELECT   SRole.RoleID AS id, SRole.RoleName AS name
		FROM      SRole
		WHERE   SRole.IsDelete = 0
	END

	IF @Type = 'InquireRoleData'--查询角色数据
	BEGIN
	SELECT @ListCount = COUNT(T.RoleID)
	FROM(SELECT RoleID FROM SRole WHERE SRole.IsDelete = 0 AND (SRole.CreateTime >= ISNULL(@BeginDate, SRole.CreateTime)) AND (SRole.CreateTime <= ISNULL(@EndDate, SRole.CreateTime)) AND (SRole.RoleName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SRole.Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')) T
		--分页查询结果
		SELECT   SRole.RoleID, SRole.RoleName, CONVERT(CHAR(20), SRole.CreateTime, 120) AS CreateTime, @ListCount AS tbCount
		FROM      SRole
		WHERE SRole.IsDelete = 0 AND (SRole.CreateTime >= ISNULL(@BeginDate, SRole.CreateTime)) AND (SRole.CreateTime <= ISNULL(@EndDate, SRole.CreateTime)) AND (SRole.RoleName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SRole.Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')
		ORDER BY CreateTime DESC
		OFFSET (CAST(@Page AS INT) -1) * @PageSize  ROWS FETCH NEXT CAST(@PageSize AS INT) ROWS ONLY
	END
	
	IF @Type = 'InsertRoleData'--新增角色数据
	BEGIN
		INSERT INTO SRole(RoleName)
		VALUES   (@RoleName)
	END
	
	IF @Type = 'UpdateRoleData'--更新角色数据
	BEGIN
		UPDATE  SRole
		SET         RoleName = @RoleName
		WHERE IsDelete = 0 AND RoleID = @RoleID
	END
	
	IF @Type = 'DeleteRoleData'--删除角色数据
	BEGIN
		UPDATE  SRole
		SET         IsDelete = 1
		WHERE IsDelete = 0 AND RoleID = @RoleID
	END
	
	-----------------------------------------------------------------------------------------==>>明细数据
	
	IF @Type = 'InquireMenuBehaviorData'--查询所有菜单的行为数据
	BEGIN
		SELECT   SMenu.MenuID, SMenu.ParentID, SMenu.Title, SMenu.Behavior
		FROM      SMenu
		WHERE IsDelete = 0
		ORDER BY SMenu.Sort
	END

	IF @Type = 'InquireRoleDetailData'--查询当前角色明细数据
	BEGIN
		SELECT   SRoleDetail.Behavior, SMenu.MenuID
		FROM      SRoleDetail INNER JOIN SMenu ON SRoleDetail.MenuID = SMenu.MenuID
		WHERE SRoleDetail.IsDelete = 0 AND SRoleDetail.RoleID = @RoleID
	END
	
	IF @Type = 'InsertRoleDetailData'--新增角色明细数据
	BEGIN
		INSERT INTO SRoleDetail(RoleID, MenuID, Behavior)
		VALUES   (@RoleID, @MenuID, @Behavior)
	END
	
	IF @Type = 'DeleteRoleDetailData'--删除角色明细数据
	BEGIN
		UPDATE  SRoleDetail
		SET         IsDelete = 1
		WHERE IsDelete = 0 AND RoleID = @RoleID
	END

	-----------------------------------------------------------------------------------------
	
	IF @Type = 'InquireRoleDetail'--查询角色明细数据
	BEGIN
		SELECT   SRoleDetail.Behavior, SMenu.Title, SMenu.Link
		FROM      SRoleDetail INNER JOIN SMenu ON SRoleDetail.MenuID = SMenu.MenuID
		WHERE SRoleDetail.IsDelete = 0 AND SRoleDetail.RoleID = @RoleID AND SMenu.Link = @QueryLikeStr
	END

END
--==>RoleManage存储进程
GO
--==>LogManage存储进程
CREATE PROCEDURE [dbo].[LogManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@UserID int = null,--用户ID
@UserIP nvarchar(max) = null,--用户IP
@RequestPath nvarchar(max) = null,--请求路径
@Controller nvarchar(max) = null--操作的控制器

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------

	IF @Type = 'InquireLogData'--查询操作日志
	BEGIN
	SELECT @ListCount = COUNT(T.LogID)
	FROM(SELECT LogID FROM SLog INNER JOIN SUser ON SLog.UserID = SUser.UserID WHERE SLog.IsDelete = 0 AND (SLog.CreateTime >= ISNULL(@BeginDate, SLog.CreateTime)) AND (SLog.CreateTime <= ISNULL(@EndDate, SLog.CreateTime)) AND (SUser.UserName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Accounts LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SLog.Controller LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SLog.CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')) T
		--分页查询结果
		SELECT   SLog.LogID, SLog.RequestPath, SLog.Controller, SLog.UserIP, SUser.UserName, CONVERT(CHAR(20), SLog.CreateTime, 120) AS CreateTime, @ListCount AS tbCount
		FROM      SLog INNER JOIN SUser ON SLog.UserID = SUser.UserID
		WHERE SLog.IsDelete = 0 AND (SLog.CreateTime >= ISNULL(@BeginDate, SLog.CreateTime)) AND (SLog.CreateTime <= ISNULL(@EndDate, SLog.CreateTime)) AND (SUser.UserName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SUser.Accounts LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SLog.Controller LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR SLog.CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')
		ORDER BY CreateTime DESC
		OFFSET (CAST(@Page AS INT) -1) * @PageSize  ROWS FETCH NEXT CAST(@PageSize AS INT) ROWS ONLY
	END

	IF @Type = 'InsertLogData'--新增操作日志
	BEGIN
		INSERT INTO SLog(UserID, UserIP, RequestPath, Controller)
		VALUES   (@UserID, @UserIP, @RequestPath, @Controller)
	END

	IF @Type = 'DeleteLogDate'--删除操作日志
	BEGIN
		UPDATE  SLog
		SET         IsDelete = 1
	END

END
--==>LogManage存储进程--表开始
GO
CREATE TABLE [dbo].[BExampler]([ExamplerID] [int] IDENTITY(1,1) NOT NULL,
[ExamplerName] [nvarchar](max) NULL CONSTRAINT [DF_BExampler_ExamplerName]  DEFAULT (' '),
[IsDelete] [bit] NULL CONSTRAINT [DF_BExampler_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_BExampler_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_BExampler_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_BExampler_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_BExampler_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_BExampler] PRIMARY KEY CLUSTERED (ExamplerID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'示例名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'ExamplerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BExampler', @level2type=N'COLUMN',@level2name=N'Remark'

GO
INSERT [dbo].[SMenu] ([ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (0, N'示例表', N'fa fa-cog', N'/BExampler/BExampler', 0, N'index,inquire,insert,update,delete,print')

GO
--==>BExamplerManage存储进程
CREATE PROCEDURE [dbo].[BExamplerManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@ExamplerID nvarchar(max) = null,--示例ID
@ExamplerName nvarchar(max) = null,--示例名称
@IsDelete nvarchar(max) = null,--作废否
@CreateTime nvarchar(max) = null,--创建时间
@CreatorID nvarchar(max) = null,--创建人ID
@Version nvarchar(max) = null,--版本
@Remark nvarchar(max) = null--备注

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------

	IF @Type = 'InquireData'--查询数据
	BEGIN
	SELECT @ListCount = COUNT(T.ExamplerID)
	FROM(SELECT ExamplerID FROM BExampler WHERE IsDelete = 0 AND (CreateTime >= ISNULL(@BeginDate, CreateTime)) AND (CreateTime <=ISNULL(@EndDate, CreateTime)) AND (ExamplerID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR ExamplerName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR IsDelete LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreatorID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Version LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')) T
		--分页查询结果
		SELECT    ExamplerID, ExamplerName, IsDelete, CreateTime, CreatorID, Version, Remark, @ListCount AS tbCount
		FROM      BExampler
		WHERE IsDelete = 0 AND (CreateTime >= ISNULL(@BeginDate, CreateTime)) AND (CreateTime <=ISNULL(@EndDate, CreateTime)) AND (ExamplerID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR ExamplerName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR IsDelete LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreatorID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Version LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')
		ORDER BY CreateTime DESC
		OFFSET (CAST(@Page AS INT) -1) * @PageSize  ROWS FETCH NEXT CAST(@PageSize AS INT) ROWS ONLY
	END
	
	IF @Type = 'InsertData'--新增数据
	BEGIN
		INSERT INTO BExampler(ExamplerName, IsDelete, CreateTime, CreatorID, Version, Remark)
		VALUES   (@ExamplerName, @IsDelete, @CreateTime, @CreatorID, @Version, @Remark)
	END
	
	IF @Type = 'UpdateData'--更新数据
	BEGIN
		UPDATE  BExampler
		SET         ExamplerName = @ExamplerName, IsDelete = @IsDelete, CreateTime = @CreateTime, CreatorID = @CreatorID, Version = @Version, Remark = @Remark
		WHERE IsDelete = 0 AND ExamplerID = @ExamplerID
	END
	
	IF @Type = 'DeleteData'--删除数据
	BEGIN
		UPDATE  BExampler
		SET         IsDelete = 1
		WHERE IsDelete = 0 AND ExamplerID = @ExamplerID
	END
	
END
--==>BExamplerManage存储进程--表开始
GO
CREATE TABLE [dbo].[BTest]([TestID] [int] IDENTITY(1,1) NOT NULL,
[TestName] [nvarchar](max) NULL CONSTRAINT [DF_BTest_TestName]  DEFAULT (' '),
[TestBool] [bit] NULL CONSTRAINT [DF_BTest_TestBool]  DEFAULT ((0)),
[IsDelete] [bit] NULL CONSTRAINT [DF_BTest_IsDelete]  DEFAULT ((0)),
[CreateTime] [datetime] NULL CONSTRAINT [DF_BTest_CreateTime]  DEFAULT (getdate()),
[CreatorID] [int] NULL CONSTRAINT [DF_BTest_CreatorID]  DEFAULT ((0)),
[Version] [int] NULL CONSTRAINT [DF_BTest_Version]  DEFAULT ((0)),
[Remark] [nvarchar](max) NULL CONSTRAINT [DF_BTest_Remark]  DEFAULT (' '),
CONSTRAINT [PK_ZFramework_BTest] PRIMARY KEY CLUSTERED (TestID ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测试名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'TestName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'测试布尔' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'TestBool'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作废否' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'CreatorID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BTest', @level2type=N'COLUMN',@level2name=N'Remark'

GO
INSERT [dbo].[SMenu] ([ParentID], [Title], [Icon], [Link], [Sort], [Behavior]) VALUES (0, N'测试表', N'fa fa-cog', N'/BTest/BTest', 0, N'index,inquire,insert,update,delete,print')

GO
--==>BTestManage存储进程
CREATE PROCEDURE [dbo].[BTestManage]
------------------------------------------------
-----=====>>>>>-----基本字段-----<<<<<=====-----
------------------------------------------------
@Type nvarchar(max) = null,                     --SQL语块
@Page int = null,                               --页数
@PageSize int = null,                           --页大小
@BeginDate datetime = null,                     --查询开始日期
@EndDate datetime = null,                       --查询结束日期
@QueryLikeStr  nvarchar(max) = null,            --模糊查询字符串
@OperationUserID int = null,                    --操作人ID
------------------------------------------------
-----=====>>>>>-----业务字段-----<<<<<=====-----
------------------------------------------------
@TestID nvarchar(max) = null,--测试ID
@TestName nvarchar(max) = null,--测试名称
@TestBool nvarchar(max) = null,--测试布尔
@IsDelete nvarchar(max) = null,--作废否
@CreateTime nvarchar(max) = null,--创建时间
@CreatorID nvarchar(max) = null,--创建人ID
@Version nvarchar(max) = null,--版本
@Remark nvarchar(max) = null--备注

AS
BEGIN
	-----------------------------------------------------------------------------------------
	DECLARE @ListCount int = 0;--定义表数量的变量
	-----------------------------------------------------------------------------------------

	IF @Type = 'InquireData'--查询数据
	BEGIN
	SELECT @ListCount = COUNT(T.TestID)
	FROM(SELECT TestID FROM BTest WHERE IsDelete = 0 AND (CreateTime >= ISNULL(@BeginDate, CreateTime)) AND (CreateTime <=ISNULL(@EndDate, CreateTime)) AND (TestID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR TestName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR TestBool LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR IsDelete LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreatorID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Version LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')) T
		--分页查询结果
		SELECT    TestID, TestName, TestBool, IsDelete, CreateTime, CreatorID, Version, Remark, @ListCount AS tbCount
		FROM      BTest
		WHERE IsDelete = 0 AND (CreateTime >= ISNULL(@BeginDate, CreateTime)) AND (CreateTime <=ISNULL(@EndDate, CreateTime)) AND (TestID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR TestName LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR TestBool LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR IsDelete LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreateTime LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR CreatorID LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Version LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%' OR Remark LIKE '%' + RTRIM(LTRIM(@QueryLikeStr )) + '%')
		ORDER BY CreateTime DESC
		OFFSET (CAST(@Page AS INT) -1) * @PageSize  ROWS FETCH NEXT CAST(@PageSize AS INT) ROWS ONLY
	END
	
	IF @Type = 'InsertData'--新增数据
	BEGIN
		INSERT INTO BTest(TestName, TestBool, IsDelete, CreateTime, CreatorID, Version, Remark)
		VALUES   (@TestName, @TestBool, @IsDelete, @CreateTime, @CreatorID, @Version, @Remark)
	END
	
	IF @Type = 'UpdateData'--更新数据
	BEGIN
		UPDATE  BTest
		SET         TestName = @TestName, TestBool = @TestBool, IsDelete = @IsDelete, CreateTime = @CreateTime, CreatorID = @CreatorID, Version = @Version, Remark = @Remark
		WHERE IsDelete = 0 AND TestID = @TestID
	END
	
	IF @Type = 'DeleteData'--删除数据
	BEGIN
		UPDATE  BTest
		SET         IsDelete = 1
		WHERE IsDelete = 0 AND TestID = @TestID
	END
	
END
--==>BTestManage存储进程