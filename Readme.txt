 CSLA + NHibernate CRUD туториал
Какие фишки тут есть:
1. CSLA бизнес объекты(наследуются от BusinessBase<>)  и бизнесс коллекции(BusinessListBase<T,U>)
2. FluentNhibernate маппинг
3. TPT паттерн(Medicine : Object иерархия правильно маппится на базу, на деннемеере тоже реализовано)
4. Фабрики объектов и DataPortal как шина между BO и DAL

Что не сделано:
1. BusinessRules - мы не юзаем этот механизм от csla на проекте, но у нас реализован очень похожий, так что будет полезно ознакомиться(in progress)
2. Child_Insert/Child_Update
3. Показать как можно работать с FieldManager-ом