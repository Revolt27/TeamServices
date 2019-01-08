USE DevelopBase
GO

DROP TABLE IF EXISTS twt.Files

CREATE TABLE twt.Files
(
     Id          INTEGER IDENTITY(1,1)
    ,Name        NVARCHAR(256)
    ,Description NVARCHAR(1024)
    ,FileName    NVARCHAR(256)
)

INSERT INTO twt.Files
(
     Name
    ,Description
    ,FileName    
)
VALUES
(
     'Отсутствие на рабочем месте'
    ,'Заявление об отсутствии сотрудника на рабочем месте.'
    ,'Шаблон отсутствие на рабочем месте.docx'
),
(
     'Неоплачиваемый отпуск'
    ,'Заявление на неоплачиваемый отпуск'
    ,'Шаблон ежегодный оплачиваемый отпуск.docx'
),
(
     'Оплачиваемый отпуск'
    ,'Заявление на ежегодный отпуск с сохранением заработной платы.'
    ,'Шаблон неоплачиваемый отпуск.docx'
)

SELECT fls.Id, fls.Name, fls.Description, fls.FileName FROM twt.Files AS fls