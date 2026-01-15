USE [MovieData]
GO

/****** Object:  Table [dbo].[Users] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Users](
        [UserID] [int] IDENTITY(1,1) NOT NULL,
        [Username] [nvarchar](50) NOT NULL UNIQUE,
        [PasswordHash] [nvarchar](256) NOT NULL,
        [Salt] [nvarchar](100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
    )
END
GO

-- Insert default user "Ayman" with password "12345"
-- Salt:  "h8x9p2k1m4" (random example string)
-- Hash:  SHA256("12345" + "h8x9p2k1m4") = 985cd0e0f403204b22a3e2d36602e39070062b56113cfb6193fc54ebd10f14f2
-- Please regenerate this in production!

    IF EXISTS (SELECT 1 FROM [dbo].[Users] WHERE Username = 'Ayman')
    BEGIN
        UPDATE [dbo].[Users]
        SET PasswordHash = '985cd0e0f403204b22a3e2d36602e39070062b56113cfb6193fc54ebd10f14f2',
            Salt = 'h8x9p2k1m4'
        WHERE Username = 'Ayman'
    END
    ELSE
    BEGIN
        INSERT INTO [dbo].[Users] (Username, PasswordHash, Salt)
        VALUES ('Ayman', '985cd0e0f403204b22a3e2d36602e39070062b56113cfb6193fc54ebd10f14f2', 'h8x9p2k1m4')
    END
GO
