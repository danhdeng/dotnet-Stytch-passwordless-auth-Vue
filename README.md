# dotnet-Stytch-passwordless-auth-Vue

# sign up for Stytch Authentication

https://stytch.com/

# Client App Setup

# create a Vue 3 app using vite

pnpm create vite@latest

# install project dependencies

pnpm vuex vue-router

# install development dependencies

pnpm install -D autoprefixer postcss tailwindcss

# Server setup

dotnet new webapi --name MindfulGift.API

# add package to the project

<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.4" />
    <PackageReference Include="Microsoft.Extensions.Logging" Version="6.0.0" />
    <PackageReference Include="Microsoft.Extensions.Options" Version="6.0.0" />
    <PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.14.0" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="6.0.4" />

# prepare the entity framework migration

dotnet ef migrations add initial-migration

# update entity framework to the lastest version

dotnet tool update --global dotnet-ef

# update database with the migrations

dotnet ef database update
