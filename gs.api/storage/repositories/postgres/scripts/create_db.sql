CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Organizations" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Organizations" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180226203345_initial', '2.0.1-rtm-125');

ALTER TABLE "Organizations" ALTER COLUMN "Name" TYPE varchar(50);
ALTER TABLE "Organizations" ALTER COLUMN "Name" SET NOT NULL;
ALTER TABLE "Organizations" ALTER COLUMN "Name" DROP DEFAULT;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20180226204333_add-annitations', '2.0.1-rtm-125');

