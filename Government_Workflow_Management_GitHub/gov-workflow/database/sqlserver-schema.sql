-- Optional SQL Server schema example. The runnable demo uses SQLite by default.
CREATE TABLE WorkflowRequests (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(120) NOT NULL,
    Department NVARCHAR(80) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL DEFAULT '',
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    CreatedUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT CK_WorkflowRequests_Status CHECK (Status IN ('Pending','Approved','Rejected'))
);
