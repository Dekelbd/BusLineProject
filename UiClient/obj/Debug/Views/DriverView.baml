   M S B A M L   `   `   `  ����C  ?UiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UiClient.ViewsUiClient.Views  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullB-clr-namespace:Model.Interfaces;assembly=ModelModel.Interfaces 5      9!clr-namespace:UiClient.ConvertersUiClient.Converters  5      9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5	          UiClient.Views.DriverView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:UiClient.Views     5      D
interfaces-clr-namespace:Model.Interfaces;assembly=Model     5      8
converters!clr-namespace:UiClient.Converters     5      8
viewmodels!clr-namespace:UiClient.ViewModels     5	        � 	Resources  5      :   4UiClient.Converters.DriverInfoToStringMultiConverter $   DriverInfoToStringMultiConverter  DriverListBoxItemTemplate �� DataType  Model.Interfaces.Driver `� 	Converter �� Path��%{  &	        &	      7     5   
   66   �� 5   
   "  69   .R�5      �� .+�5      �� $��2q�6   $	��120��6'   $��1��66   $��1��6C   $��15(�6S   ��5      `� 5      8   .1�5      �� $ 	FirstName�6&   �� 5      $ LastName�6&   �� 5      $ PhoneNumber�6&   �� 5      $ Address�6&   5      5      5      5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $��* �6    � ColumnDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $��* �6   .+�5-   
   �� $��0��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $	��225��6K   $��55��6W   .+�5.      �� $��0,15,0,3q�6   $��17(�6+   $��Driver Name :��69   $
��Bold"�6N   �� 5/      -   5         ��Name$ FilterTextbox��5/      $	��101��50      $��25��6   $��5,7,0,3q�6+   $��17(�6<   ���	#FFF8FFFF��5/   -   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�50   J   51      �� 52   
   -   5        $��AddDriverButton��52      $��4��6P   $��0��6`   $��50��6m   $��50��6x   
�������$��0q�53   $   ��52   (   �� *AddNewDriverCommand+.��54      �� .+�55      �� $��Icons/add.png��6   56      57      �� 58   
   #��[ 68   $��4��59   	   $	��273��6   $��5��6*   $	��626��6;   $��	36,81,0,0q�6G   ��58      �� *FilterDrivers+59   G   5:      5;      