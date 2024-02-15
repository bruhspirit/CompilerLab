<Window x:Class="CompilerLab.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:CompilerLab"
        mc:Ignorable="d"
        Title="" Height="450" Width="800">
    <Grid>
        <ListBox>
            <Label Content="Файл" Name ="FileLabel"></Label>
            <ListBoxItem>
                <TextBlock Text="Создать - создает файл с указанным именем и с указанной дирректорией. Функция также доступна на панели инструментов." Name ="CreateBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Открыть - открывает файл с указанным именем и с указанной дирректорией. Функция также доступна на панели инструментов." Name ="OpenBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Сохранить - сохраняет изменения в открытом файле. Функция также доступна на панели инструментов." Name ="SaveBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Сохранить как - сохраняет файл с указанным именем и с указанной дирректорией." Name ="SaveAsBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Выход - закрывает открытый файл." Name="ExitBlock"></TextBlock>
            </ListBoxItem>
            <Label Content="Правка" Name="EditLabel"></Label>
            <ListBoxItem>
                <TextBlock Text="Отменить - отменяет последнее изменение в файле. Функция также доступна на панели инструментов." Name="UndoBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Повторить - повторяет последнее отмененное изменение в файле. Функция также доступна на панели инструментов." Name ="RedoBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Вырезать - вырезает и сохраняет в буфере обмена выделенный текст. Функция также доступна на панели инструментов." Name="CutBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Копировать - копирует  в буфер обмена выделенный текст. Функция также доступна на панели инструментов." Name ="CopyBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Вставить - вставляет текст из буфера обмена. Функция также доступна на панели инструментов." Name ="PasteBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Удалить - удаляет выделенный выделенный текст." Name="DeleteBlock"></TextBlock>
            </ListBoxItem>
            <ListBoxItem>
                <TextBlock Text="Выделить все - выделяет весь текст в документе." Name="SelectAllBLock"></TextBlock>
            </ListBoxItem>
            <Label Content="Настройки" Name="SettingsLabel"></Label>
            <ListBoxItem>
                <TextBlock Text="Язык - смена языка в программе." Name="LangBlock"></TextBlock>
            </ListBoxItem>
            <Label Content="Панель инструментов" Name="InstPanel"></Label>
            <ListBoxItem>
                <TextBlock Text="Содержит функции для работы с текстом, а также кнопки запустить, вызов справки и информации о программе и окна изменения размера шрифта в программе. При наведении на элементы пользователь может увидеть подсказки описывающие действия назначенные кнопкам" Name="Toolblock"></TextBlock>
            </ListBoxItem>

        </ListBox>
    </Grid>
</Window>
