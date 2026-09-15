-- Nascore PostgreSQL Veritabanı Tabloları Oluşturma Scripti

CREATE TABLE IF NOT EXISTS "News" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "ImageUrl" VARCHAR(500) NOT NULL,
    "PublishedDate" TIMESTAMP NOT NULL,
    "Category" VARCHAR(100) NOT NULL,
    "Content" TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS "Feature" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Description" TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS "ServiceItem" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "Description" TEXT NOT NULL,
    "IconClass" VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS "Skill" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Percentage" INT NOT NULL
);

CREATE TABLE IF NOT EXISTS "Testimonial" (
    "Id" SERIAL PRIMARY KEY,
    "AuthorName" VARCHAR(255) NOT NULL,
    "AuthorRole" VARCHAR(255) NOT NULL,
    "Company" VARCHAR(255) NOT NULL,
    "AvatarUrl" VARCHAR(500),
    "Stars" INT NOT NULL DEFAULT 5,
    "Quote" TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS "ProjectCategory" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "FilterValue" VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS "ProjectItem" (
    "Id" SERIAL PRIMARY KEY,
    "Title" VARCHAR(255) NOT NULL,
    "SubTitle" VARCHAR(255) NOT NULL,
    "ImageUrl" VARCHAR(500) NOT NULL,
    "FilterGroups" TEXT[] NOT NULL
);

CREATE TABLE IF NOT EXISTS "ContactMessage" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Email" VARCHAR(255) NOT NULL,
    "Phone" VARCHAR(50),
    "Subject" VARCHAR(255) NOT NULL,
    "Message" TEXT NOT NULL,
    "IsKvkkAccepted" BOOLEAN NOT NULL,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);
