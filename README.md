# Кросплатформене програмування
Ходацький Володимир
ІПЗ-32
Варіант 24

## Команди для запуску проектів Лабораторні 1 - 3

Для запуску Build/Run/Test для певних лабораторних введіть наступні команди з корня репозиторію:

Щоб запустити білд лабораторної:
```bash
dotnet build Build.proj -t:Build -p:Solution=Lab1
```

Щоб запустити код лабораторної:
```bash
dotnet build Build.proj -t:Run -p:Solution=Lab1
```

Щоб запустити тести лабораторної:
```bash
dotnet build Build.proj -t:Test -p:Solution=Lab1
```

Щоб використовувати ці команди для інших лабораторних, замість Lab1, вводити номер потрібної лабораторної, наприклад: -p:Solution=Lab2

## Команди для запуску проектів Лабораторна 4

Для запуску  певних лабораторних введіть наступні команди з папки Lab4 репозиторію:

Щоб перейти в папку Lab4:
```bash
cd Lab4
```

Щоб запустити лабораторну 1:
```bash
dotnet run run lab1 --input Lab1\INPUT.TXT --output Lab1\OUTPUT.TXT
```

Щоб запустити лабораторну 2:
```bash
dotnet run run lab2 --input Lab2\INPUT.TXT --output Lab2\OUTPUT.TXT
```

Щоб запустити лабораторну 3:
```bash
dotnet run run lab3 --input Lab3\INPUT.TXT --output Lab3\OUTPUT.TXT
```

Щоб перевірити версію:
```bash
dotnet run version
```


Результат виконання на Віртуальній Машині Windows:
![VirtualBox_Windows VM_14_11_2024_02_51_22](https://github.com/user-attachments/assets/d094a35a-ba47-4825-bcd2-5a5ba0e846d2)

Результат виконання на Віртуальній Машині Linux:
![VirtualBox_CrossPlatform_linux_1731545809067_97413_14_11_2024_03_11_08](https://github.com/user-attachments/assets/0ba92da4-90d0-4179-a0d5-211e97003b0a)
