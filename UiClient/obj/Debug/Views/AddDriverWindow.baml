   M S B A M L   `   `   `  ����C  ?UiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5   	   @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullB-clr-namespace:Model.Interfaces;assembly=ModelModel.Interfaces 5   	   9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5   	   $    UiClient.Views.AddDriverWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:UiClient.ViewModels     5   	   D
interfaces-clr-namespace:Model.Interfaces;assembly=Model     5   	   8
viewmodels!clr-namespace:UiClient.ViewModels     5   	     � Title$  AddDriverWindow��5   	   $	��500��6!   $	��800��6.   .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��140 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��220 �6   �� 5      $	��255 �6   �� 5      $��55 �6   .+�5    
   �� -   5         ��Name$ CreateNewDriver��5       $��3��6-   $��0��6=   $
��Bold"�6J   $��Center=�6\   $��25(�6y   $��Create New Driver��6�   �� 5!   
   $��First Name :��6   $��0��6)   $��2��69   $��17(�6F   $
��Left=�6T   $��10,0,0,0q�6o   �� 5"   
   $��1��6.   $��2��6>   $��90��6K   $��20��6V   $��0,0,0,28q�6b   ���	#FFF8FFFF��6   �� *	FirstName+6t   �� 5#   
   $��Last Name :��6   $��0��6(   $��3��68   $��17(�6E   $
��Left=�6S   $��10,0,0,0q�6n   �� 5$   
   $��1��6-   $��3��6=   $��90��6J   $��20��6U   $��0,0,0,28q�6a   ���	#FFF8FFFF��6   �� *
LastName+6s   �� 5%   
   $��	Address :��6   $��0��6&   $��4��66   $��17(�6C   $
��Left=�6Q   $��10,0,0,0q�6l   �� 5&   
   $��1��6,   $��4��6<   $��90��6I   $��20��6T   $��0,0,0,28q�6`   ���	#FFF8FFFF��6   �� *	Address+6r   �� 5'   
   $��Phone Number :��6   $��0��6+   $��5��6;   $��17(�6H   $
��Left=�6V   $��10,0,0,0q�6q   �� 5(   
   $��1��60   $��5��6@   $��90��6M   $��20��6X   $��0,0,0,28q�6d   ���	#FFF8FFFF��6   �� *PhoneNumber+6v   �� 5)   
   -   5        $��
SaveDriver��5)      $��3��6L   $��7��6\   
�������$
��Bold"�6~   $��12(�6�   ��6#   �� *SaveNewDriverCommand+.��6�   Save6�   5+      5,      