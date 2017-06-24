﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9
{
    class Program
    {
        static void Main(string[] args)
        {
            var docsDb = new DocumentsDb();
            //docsDb.Database.Delete();
            //foreach (var doc in Docs)
            //    docsDb.Documents.Add(doc);
            //docsDb.SaveChanges();

            var bm25Searcher = new Bm25(docsDb.Documents);
            Console.WriteLine("Введите запрос:");
            var query = Console.ReadLine();

            foreach (var doc in bm25Searcher.RankDocsByQuery(query))
                Console.WriteLine(doc.Text + "\n");

            Console.ReadLine();
        }
        
        private static IEnumerable<Document> Docs = new[]
        {
            #region
            new Document(@"Босс рассказал пошлый бородатый анекдот:
« - Ты мой пончик!
- Я такая толстая?!
- Нет, сладкая и с дырочкой!»
Все сделали вид, что поржали и углубились в работу. Через минут 5 приходит с производства начальник лаборатории, громко здоровается со всеми и обращается к Лёне, коллеге моему: «Что там с заявочкой моей, Лёнчик-Пончик?».
Работы сегодня не будет больше, чувствую…"),
            new Document(@"xxx: Я сел на Дмитров ехал до окружной на выходе стояла ты светлые волосы красивые глаза сорные штаны ты была с телефоном и наушником мы посмотрели друг на друга улыбнулись на выходе помогали друг другу руками отзовись ты очень красивая)))
yyy: Помогали друг другу руками? Ребят, такие подробности лучше оставить за кадром"),
            new Document(@"xxx: господи, как же меня тошнит от этих юнит-тестов уже... а щас ещё штук 1000 надо писать...
yyy: тяжело на стейджинге — легко в бою
xxx: в бою сука легко - но сука серверу, а не мне"),
            new Document(@"Я девушка, нахожусь в декрете. Ищу в интернете всё, связанное с ребенком и кулинарией. И никак понять не могу, что я смотрела и куда заходила, что мне контекстная реклама предлагает купить стальную арматуру. Уже вторую неделю."),
            new Document(@"xxx: Да я что то заметил, что я стал привлекать женское внимание особенно после смены имиджа.
yyy: может ты стал вызывать у них жалость?"),
            new Document(@"Объяснял на днях студентам, как задача о совершенном паросочетании в двудольном графе сводится к задаче о максимальном целочисленном потоке в некоторой сети (это теория графов -- область дискретной математики). Если коротко, то в задаче о совершенном паросочетании есть N мальчиков и N девочек, и указаны пары мальчик-девочка, которые типа нравятся друг другу. А задача в том, чтобы разбить их на непересекающиеся пары, чтобы создать N типа счастливых семей. Только сейчас понял, почему публика так радовалась, когда речь пошла о потоках в сетях: ""пусть поток пойдёт из мальчика b(i) в девочку g(j)"", повторял лектор."),
            new Document(@"Как плохо без авто.... Автобус такой медленный... Одна бабулька другой рассказывает историю своей жизни, первые 20 мин было неинтересно, но теперь интрига. Вот выйду из автобуса, так и не узнаю чем всё закончилось ("),
            new Document(@"xxx: Привет, это xxx не могу закрыть физику, у тебя связи есть?
yyy: Нет, связей увы нету.
xxx: Слушай а не знаешь кто из преподов деньги берёт?
yyy: Я вообщето не учусь с вами уже пол года, меня ж выгнали...
xxx: как не учишься? ты ж в контакте есть?"),
            new Document(@"xxx: подруга разбирает какую-то коробку. там всякий старый хлам... и тут! опа - флешка! в реально кожаном чехле, с тру заклепками под метал, ну прям мечта!!! я хватаю, кручу в руке, открываю колпак (а он на кожаном шнурике висит, ваще кайф) и говорю подруге: ""ты какова хера не пользуешься???"" и одновременно корпус флехи переворачиваю, а там надпись выбитая на коже: 256МБ..."),
            new Document(@"Пришел на работу с бодуна, невыспавшийся.. Зашел в архив (такой где хранят папки с бумажками) поспать.. Снится мне следующее: заходит в этот же архив коллега и начинает отсчитывать мне на стол старые советские купюры с ильичом со словами ""Серёж, извини, но зарплату выдали такими.. Придется брать..""
На этом месте я в ужасе просыпаюсь и в состоянии полусна лезу в ящик со старыми профсоюзными билетами в поисках своего)) Хватая первый попавшийся выбрасываю руку с ним перед собой с криком ""ВОТ!"" и в этот момент входит начальник)) пришлось долго объясняться с ним))"),
            #endregion
        };
    }
}
