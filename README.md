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
