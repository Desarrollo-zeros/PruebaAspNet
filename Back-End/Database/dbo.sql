/*
 Navicat Premium Data Transfer

 Source Server         : Stese
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : stese.ml:1433
 Source Catalog        : ZerosPruebaAspNet
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 25/08/2020 23:53:19
*/


-- ----------------------------
-- Table structure for __MigrationHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__MigrationHistory]
GO

CREATE TABLE [dbo].[__MigrationHistory] (
  [MigrationId] nvarchar(150) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [ContextKey] nvarchar(300) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [Model] varbinary(max)  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE Modern_Spanish_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__MigrationHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __MigrationHistory
-- ----------------------------
INSERT INTO [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202008260417005_InitialCreate', N'Infraestructure.Data.DBContext', 0x1F8B0800000000000400ED59CD6EE33610BE17E83B083AB545D6B29343DBC0DE85D7498AA09B388893456F012D8D1DB614A5925460A3E893F5D047EA2B7428EA9F92FFB2D976812097883FDF0C673ECE70C6FFFCF5F7F0DD2A64CE130849233E7207BDBEEB00F7A380F2E5C84DD4E2CD0FEEBBB75F7F353C0FC295F3315F77A2D7E14E2E47EEA352F1A9E749FF1142227B21F54524A385EAF951E89120F28EFBFD1FBDC1C003847011CB7186B709573484F4033F2711F7215609615751004C66E338334B519D6B12828C890F23F7922F0401A944E2AB4440EF8C28E23A634609EA3203B6701DC279A488424D4FEF25CC9488F87216E3006177EB1870DD823009D9094ECBE5BB1EA67FAC0FE3951B73283F912A0AF7041C9C64D6F19ADB0FB2B15B582FB56C183358E963A7464CED17B94E53D2E98409BD68E49EE130E5BD8F8425309DFF0ABE923DBDE7C8313347050B902CFAEFC899244CBB62C4215182B023E7269933EAFF0CEBBBE837E0239E3056D50AF5BA11510C42AD33A552FFBA8ED1001D86EC739D2BB2FA007CA91E472EFEEB3A177405413E9279F09E53242B6E423EE0E7354A227306C5BCB751EC380804C8FF40F0CD63C46183D8C1C9F3A50EBD8AF3ABE3E778F7D4BA428909A3C0D50EA4487752903DB3E3D35202E76A0315ABDDC222676F6099D66B6E6C1A5BEF31C7B8E4EAE4B8C56C9523CF5424E027E0208882E0862805826B0C48ADB6CDB1E676657EC560D433037BD26322404B1FAB1C0A831CDC61C0DC8E744D9EE8323D4A1333E28AE065769D5B60E902F948E34CCB6CF22167C28588C2DB8895DBB299873B2296A0D58A5AA76751227C8B8725E136D3D060EDC543B3E595882F45C4D4ADDBF5DE998419BF9E43C19C631D14CC19BA0B05C752463E4D35A97330D7A27EAC731E389B552ACD5D90F90A094863A41CCA1FB9DF59B6EA042DAE5A0534B34D1D73E036E93AE567C0408133F6CD2B6442A44F02DB516897A03E820C07A1294618EA83CF2CBC56CABE0E94FB34266CA3E68D5D3B5E23AD5581DF9C398318B8BE011BFDB08BE092D9B6F8424AC358DB6C33F42A84B2435DAA2CC50B9DA970F65E8FC0AA2DE2E1BB350B7A324BF64DD668C419A8DA7130B897446F70C6A25D03A0480F36424EE50644E5B0164E718D2B8BDA2F7AD3FA5B2F59A1795569CB895BAF551526375EF376D44FD812500A9796158B674A96BCB4F13A6A9BE11589637CF6556A9D6CC499994267F266B6FFFB3F34189E2FDD0D042C24618E214B68CC6A930570418554BAB89A131DE12741682D2B09DCC1AD5C4E9DA3B6AB72C2E5EBF5FF451AB3AABD5E3B734A0B5EE0A1421D24D21C6A39DADE98169A8411D192B027114B426EBE694BB84877672FEDCE1CBCE130E9A216CC2E9DB252A9AA1637436D9A75A114954F1587E483FB2065A54C15273643AD96F21AA6DAD91795377155966F861F88159F8CB80625AC586F91CF4A90752EEFC6F43C2E3D9FEA59EC3D80EB5D3B5FC9FE0590BD789DD4B86E3258BB635E94EA56BE6B2E29A41779AF91DF8659AED9DEE0B3928F59E23A68A3271AE8C4335B4B05A1A1D4EC7796BF35F2055784D30552CF5478EE717F70DCE810FE7FBA759E94016BC9D5767BE68022D566CAF6229516C51ED536DD5A86EE5951F26AA78F3F11E13F12F14D4856DFEE0D45EADDBBE781C5D58E5C0E65F5E4F604AD2627831CE0B7EE7C1F6BB6824F4D3BFDFBADADBC3D5B28AF5CF9F2B85206F78A49ADC2F0120BD3D5C8FD23DD75EA5CFEF2506C3C72A602A3DFA9D377FE3C9050873744B210FC799B15569177580BE6B09E475711B2CBD53AA4C9B193A80D4F84CFD6D7B0ABC75D7A171B5A17E60180C173AE5F9886D47E47CDDED1D7D8D4D66885EFE82CBC7CD3A3668C6AD5BA438FA3AD39F2325D0DFB358734AAFCA88B2496745942E89F7839F83502156B74559053B9A151BEA4112CAF40114CA5642C145DE02171DAC7F09EFE8C96FE723972CFC33904977C9AA83851786408E7ACD635D7F76193FCB47553D779388DD3AEF5A73802AA49F56B60CADF27940585DE172DD1BA03425FB42CDD6A5F2A9D7697EB02E9DA2A4CBA8032F315F1E10EB06C413039E533F20487E8762FE1032C89BFCE1FE5DD20DB1D5137FBF08C92A520A1CC30CAFDF8891C0EC2D5DB7F01292DE1C8DB200000, N'6.1.3-40302')
GO


-- ----------------------------
-- Table structure for clients
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[clients]') AND type IN ('U'))
	DROP TABLE [dbo].[clients]
GO

CREATE TABLE [dbo].[clients] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [names] nvarchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [address] nvarchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [phone] nvarchar(13) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [created_at] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[clients] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of clients
-- ----------------------------
SET IDENTITY_INSERT [dbo].[clients] ON
GO

INSERT INTO [dbo].[clients] ([id], [names], [address], [phone], [created_at]) VALUES (N'2', N'carlos andrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2020-08-25 23:17:31.0000000')
GO

INSERT INTO [dbo].[clients] ([id], [names], [address], [phone], [created_at]) VALUES (N'3', N'carlos andrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2020-08-25 23:17:31.0000000')
GO

INSERT INTO [dbo].[clients] ([id], [names], [address], [phone], [created_at]) VALUES (N'4', N'carlos andrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2020-08-25 23:17:31.0000000')
GO

INSERT INTO [dbo].[clients] ([id], [names], [address], [phone], [created_at]) VALUES (N'5', N'carlos andrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2020-08-25 23:17:31.0000000')
GO

SET IDENTITY_INSERT [dbo].[clients] OFF
GO


-- ----------------------------
-- Table structure for contacts
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[contacts]') AND type IN ('U'))
	DROP TABLE [dbo].[contacts]
GO

CREATE TABLE [dbo].[contacts] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [names] nvarchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [address] nvarchar(max) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [phone] nvarchar(13) COLLATE Modern_Spanish_CI_AS  NOT NULL,
  [client_id] int  NOT NULL
)
GO

ALTER TABLE [dbo].[contacts] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of contacts
-- ----------------------------
SET IDENTITY_INSERT [dbo].[contacts] ON
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'1', N'carlos andrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'2', N'carlos  xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'5')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'3', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'4', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'5', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'3')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'6', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'3')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'7', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'3')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'8', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'9', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'10', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'4')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'11', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'4')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'12', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'13', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'2')
GO

INSERT INTO [dbo].[contacts] ([id], [names], [address], [phone], [client_id]) VALUES (N'14', N'xandrés castilla garcia', N'cr 22 #7-50', N'3043541475', N'5')
GO

SET IDENTITY_INSERT [dbo].[contacts] OFF
GO


-- ----------------------------
-- Primary Key structure for table __MigrationHistory
-- ----------------------------
ALTER TABLE [dbo].[__MigrationHistory] ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for clients
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[clients]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table clients
-- ----------------------------
ALTER TABLE [dbo].[clients] ADD CONSTRAINT [PK_dbo.clients] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for contacts
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[contacts]', RESEED, 14)
GO


-- ----------------------------
-- Indexes structure for table contacts
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_client_id]
ON [dbo].[contacts] (
  [client_id] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table contacts
-- ----------------------------
ALTER TABLE [dbo].[contacts] ADD CONSTRAINT [PK_dbo.contacts] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table contacts
-- ----------------------------
ALTER TABLE [dbo].[contacts] ADD CONSTRAINT [FK_dbo.contacts_dbo.clients_client_id] FOREIGN KEY ([client_id]) REFERENCES [dbo].[clients] ([id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

