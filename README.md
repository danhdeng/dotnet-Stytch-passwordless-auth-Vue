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

# Tailwindcss setup referenced from

https://tailwindcss.com/docs/guides/vite

pnpm install -D tailwindcss postcss autoprefixer

# to create tailwind.config.js and postcss.config.johnsoncodehk

npx tailwindcss init -p

# add the following to the tailwind.config.js

```json
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

# add the following to postcss.config.js

```json
module.exports = {
  plugins: {
    tailwindcss: {},
    autoprefixer: {},
  }
}
```

# added main.css to main.ts file

import './main.css';
const vm = createApp(App).use(router).use(store).mount('#app');

export default vm;
