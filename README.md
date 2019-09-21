# Gemini.Core
## 背景
公司要求开发一套后台管理系统，正好借这个机会开发一个通用的框架，以后可以复用，也非常的希望能和工友们一起来学习和探讨。
## 框架介绍
Asp.net core mvc通用后台框架，前端ui框架采用layui，集成autofac/automapper/serilog等常用的第三方库；orm框架采用ef core，并且实现了仓储模式和工作单元(有很多地方说ef core不建议这样)，仓储层写了通用的接口和实现，不用每个实体写一个repository。集成简单的redis访问工具，通过依赖注入可以使用。



