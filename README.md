[![.NET Core](https://github.com/Kentico/statiq-starter-kontent-lumen/workflows/.NET%20Core/badge.svg)](https://github.com/Kentico/statiq-starter-kontent-lumen/actions)
[![Live Demo](https://img.shields.io/badge/Live-DEMO-brightgreen.svg?logo=github&logoColor=white)](https://kentico.github.io/statiq-starter-kontent-lumen)

# Kentico Kontent 💖 Statiq - Lumen Starter

Lumen is a minimal, lightweight, and mobile-first starter for creating blogs using Statiq and Kentico Kontent.

---
![Lumen - screenshot](https://i.imgur.com/vLBpkl6.png)

## Features

- Content from [Kontent](http://kontent.ai/) headless CMS.
- [Kontent Web Spotlight](https://docs.kontent.ai/tutorials/set-up-kontent/set-up-your-project/web-spotlight)
- Beautiful typography inspired by [matejlatin/Gutenberg](https://github.com/matejlatin/Gutenberg).
- [Mobile-First](https://medium.com/@mrmrs_/mobile-first-css-48bc4cc3f60f) approach in development.
- Stylesheet built using SASS and [BEM](http://getbem.com/naming/)-Style naming.
- Syntax highlighting in code blocks.
- Archive organized by tags and categories.
- Automatic Sitemap generation.
- Open Graph & Twitter Cards support
- RSS/Atom support out of the box
- Google Tag Manager support
- Automatic Dark Mode

## Getting Started

### Requirements

- [.NET Core 3.1](https://dotnet.microsoft.com/download)

### Clone the codebase

1. Click the ["Use this template"](https://github.com/Kontent/statiq-starter-kontent-lumen/generate) button to [create your own repository from this template](https://help.github.com/en/github/creating-cloning-and-archiving-repositories/creating-a-repository-from-a-template).

### Running locally

- `dotnet run -- preview`
  - You can also emulate running the project in a virtual directory by appending `--virtual-dir statiq-starter-kontent-lumen`. See all preview [options](https://statiq.dev/web/running/preview-server).
- Go to `http://localhost:5080/`

🎊🎉 **You are now ready to explore the code base!**

> By default, the content is loaded from a shared Kentico Kontent project. If you want to use your own clone of the project so that you can customize it and experiment with Kontent, continue to the next section.

### Create a content source

1. Go to [app.kontent.ai](https://app.kontent.ai) and [create an empty project](https://docs.kontent.ai/tutorials/set-up-kontent/projects/manage-projects#a-creating-projects)
1. Go to the "Project Settings", select API keys and copy the following keys for further reference
    - Project ID
    - Management API key
1. Use the [Template Manager UI](https://kentico.github.io/kontent-template-manager/import) for importing the content from [`content.zip`](./content.zip) file and API keys from previous step. Check *Publish language variants after import* option before import.

    > Alternatively, you can use the [Kontent Backup Manager](https://github.com/Kentico/kontent-backup-manager-js) and import data to the newly created project from [`content.zip`](./content.zip) file via command line:
    >
    >   ```sh
    >    npm i -g @kentico/kontent-backup-manager
    >
    >    kbm --action=restore --projectId=<Project ID> --apiKey=<Management API key> --zipFilename=content
    >    ```
    >
    > Go to your Kontent project and [publish all the imported items](https://docs.kontent.ai/tutorials/write-and-collaborate/publish-your-work/publish-content-items).

1. Map the codebase to the data source
    - adjust the `DeliveryOptions:ProjectId` key in `appSettings.json`

🚀 **You are now ready to use the site with your own Kentico Kontent project as data source!**

### Production deployment to GitHub pages

- Enable GitHub actions in your repo
- Copy the [`.github/workflows/dotnet-core.yml`](https://github.com/Kontent/statiq-starter-kontent-lumen/blob/master/.github/workflows/dotnet-core.yml) to your project
- Go to the repository secrets and set:
  - [`LinkRoot`](https://statiq.dev/framework/configuration/settings) to the relative path of your project (e.g. `/statiq-starter-kontent-lumen`) - this is to ensure that all links work properly when deployed to a subfolder
  - [`Host`](https://statiq.dev/framework/configuration/settings) to the domain of your project (e.g. `domain.tld`) - this is to ensure that absolute links are generated where required

## Configuring features

### Google Tag Manager

-> just add `"TagManagerId": "GTM-XXXXXXX"` to appsettings.json

### [Web Spotlight](https://webspotlight.kontent.ai/)

- Add [Web Spotlight](https://kontent.ai/pricing) to your current plan
- Set up [preview URLs](https://i.imgur.com/fYzG7mZ.png)
- Start editing!
![Web Spotlight Screenshot](https://i.imgur.com/0WykmeX.png)

## Original work

This template is licensed under the [MIT](LICENSE) license and the credits for the [original work](https://github.com/alxshelepenok/gatsby-starter-lumen) on the template go to [Alexander Shelepenok](https://github.com/alxshelepenok).
