# 🧠 HelpDeskAI — Sistema Web de Gestão de Chamados

O **HelpDeskAI Web** é uma aplicação desenvolvida como parte do projeto acadêmico PIM, criada para gerenciar chamados internos de suporte técnico, organizar atendimentos, distribuir tarefas entre técnicos e integrar recursos para agilizar respostas e melhorar a experiência do usuário.

Este módulo corresponde à **aplicação Web**, desenvolvida em **ASP.NET Core MVC + SQL Server + Bootstrap**, conectada à API central que integra também as aplicações **Desktop**.

---

## 🚀 Funcionalidades Principais

- 🔐 Autenticação de usuários (Administrador, Técnico e Colaborador)
- 🎫 Abertura, acompanhamento e gerenciamento de chamados
- 📊 Dashboard completo com indicadores
- 👨‍🔧 Atribuição automática de técnico por categoria/área
- 💬 FAQ
- 📂 Histórico detalhado de interações
- 📸 Upload de anexos nas solicitações
- 🔎 Filtros avançados e busca dinâmica
- ⚙️ Painel administrativo completo:
  - Gestão de usuários
  - Gestão de setores
  - Gestão de categorias
  - Gestão de FAQs
- 🌐 Integração via API com:
  - App Desktop (C# WinForms/WPF)
  - App Android (Java/Retrofit)

---

## 🏗️ Arquitetura do Sistema

[ Usuário ]
|
[ Aplicação Web MVC ]
|
[ API REST ASP.NET ]
|
[ SQL Server (Azure/Local) ]
|
[ Aplicações Desktop ]

---

## 📌 Tecnologias Utilizadas

**Frontend (Web):**
- HTML5, CSS3, Bootstrap 5
- Razor Pages / Views
- JavaScript

**Backend:**
- ASP.NET Core MVC 7
- Entity Framework Core
- Identity / JWT (quando integrado à API)

**Banco de Dados:**
- SQL Server (Local ou Azure)
- Migrations via EF Core

**Integração e AI:**
- Gemini API (Google)
- API REST interna

---

## 📁 Estrutura do Projeto

/Aplicativo Web
/Controllers
/Models
/Views
/wwwroot
appsettings.json
Program.cs
Startup.cs

---

## 🧪 Exemplos de Endpoints da API

```http
POST /api/auth/login
GET /api/chamados
POST /api/chamados/criar
PUT /api/chamados/{id}/status
GET /api/faq
POST /api/faq/ia-resposta
