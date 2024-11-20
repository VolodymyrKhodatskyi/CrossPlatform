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

## Команди для запуску проектів Лабораторної 4

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



## Команди для запуску проектів Лабораторної 5

Для запуску лабораторної з Windows:

Щоб перейти в папку Lab5:
```bash
cd Lab5
```

Щоб запустити лабораторну 5:
```bash
dotnet run --project Lab5
```



Перейти в браузері по адресі:
```bash
http://localhost:5117
```


Для запуску лабораторної з Linux:

Запуск віртуальної машини:
```bash
vagrant up linux
```

Щоб перейти в папку Lab5:
```bash
cd /vagrant/Lab5
```

Щоб запустити лабораторну 5:
```bash
dotnet run --project Lab5 --urls "http://*:5117"
```

Перейти в браузері по адресі:
```bash
http://192.168.50.4:5117
```


Результат виконання на Віртуальній Машині Linux:
![VirtualBox_CrossPlatform_linux_1732059069249_25372_20_11_2024_01_36_24](https://github.com/user-attachments/assets/5121e9ec-97a2-411f-a635-be8ed7d7b7f8)

Скриншоти Застосунку:
<img width="1280" alt="Screenshot 2024-11-20 013425" src="https://github.com/user-attachments/assets/5f5ba829-ada9-4ceb-9b18-6d9aad816dfe">
<img width="1279" alt="Screenshot 2024-11-20 014847" src="https://github.com/user-attachments/assets/513ce5b8-ca44-4abc-bbed-6bce14b21f05">
<img width="1271" alt="Screenshot 2024-11-20 013521" src="https://github.com/user-attachments/assets/978c2786-3a5a-45d5-8a86-7d0fb5080fa3">
<img width="1280" alt="Screenshot 2024-11-20 013547" src="https://github.com/user-attachments/assets/e8bebaeb-211a-4b16-acb1-24cdd695bd1e">
<img width="1280" alt="Screenshot 2024-11-20 013607" src="https://github.com/user-attachments/assets/00b3518c-29a6-4db4-babf-b667342815dd">

