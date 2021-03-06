# circular-dependency

Предположим, в солюшене (где есть много сборок, DI-контейнер, все дела) возникла необходимость вынести часть интерфейса одного сервиса в некую общую сборку, например, чтобы разорвать циклическую зависимость.

Но тогда возникает вероятность, что циклическая зависимость не разорвется а скроется до этапа сборки DI-контейнера.

Вот диаграмма минимального примера:

![diagram](https://user-images.githubusercontent.com/2421660/150165761-6ffbc090-0e21-4ab3-b4c2-e2d0b6c58a1f.png)

(за картинку спасибо @imbelousov )

Тогда можно использовать класс `Lazy`, чтобы реализация доставлялась контейнером не в конструкторе, а в момент первого запроса.

Это минимальный пример.
