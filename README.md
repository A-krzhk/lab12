<h1 style="align: center;"> Покрытие кода тестами </h1>
![image](https://github.com/A-krzhk/lab12/assets/72504907/9f83f51e-3998-4df1-ac81-7843f7921b08)
<p>Покрытие кода тестами в задаче 1, проект "Task 1", покрывает MyList на 85%, не покрытыми остались функции печати списка на экран и ручное заполнение элемента. Класс "Point" не тестировался отдельно, так как является вспомогательным для MyList, и если его функции раюотают корректно, то и Point работает корректно.</p>
<p>Покрытие кода тестами в задаче 2, проект "Task 2" составляет 92%, не покрыта функция печати таблицы на экран</p>
<p>Покрытие кода тестами в задаче 3, проект "Task3" составляет 80%, не покрытыми являются функции печати дерева на экран, а также балансировка при уровне ноды равном -2, это обусловлено тем, что протестирован случай, когда балансировка равна 2, а также левый и правые повороты, для корректировки балансировки, в таком случае тестирование случая с вершиной равной - 2 не имеет смысла. Класс PointAVL отдельно не тестировался, так как явлляется вспомогательным для дерева, и, по аналогии с первой задачей, если дерево работает корректно, то и поинт работает верно</p>
<p>Покрытие кода тестами в задаче 4, проект "Task4" составляет 86%, не протестированными являются функции вывода на экран, и функция IsReadOnly - так как это не требовалось заданием. Вспомогательный класс MyEnumerator был протестирован в ходе тестирования самой коллекции при использовании цикла foreach, отделтно он тестировался по тем же причинам, что и классы Point</p>