﻿2011. Анализ возраста
Задан возраст человека — число n. Ваша задача написать программу, которая классифицирует человека по его возрасту.
- Если это число меньше 7, то обычно это обозначает, что задан дошкольник и надо вывести "preschool child".
- Если это число от 7 до 17, то обычно это обозначает, что задан школьник и надо вывести "schoolchild m", где m — это его предполагаемый класс (число от 1 до 11, считайте, что учатся в школе с 7 лет, класс меняется раз в год).
- Если это число от 18 до 22, то обычно это обозначает, что задан студент и надо вывести "student m", где m — это его предполагаемый курс (число от 1 до 5, считайте, что учатся в университете с 18 лет, курс меняется раз в год).
- Если это число больше 22, то выведите "specialist", что обозначает квалификацию "специалист".

Входные данные
В единственной строке задано целое число n (0 ≤ n ≤ 150).

Выходные данные
Выведите искомую строку.

Пример(ы)
input.txt
10
output.txt
schoolchild 4

input.txt
20
output.txt
student 3
