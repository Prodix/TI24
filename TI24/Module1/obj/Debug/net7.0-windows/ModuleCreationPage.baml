   M S B A M L   `   `   `  ����B  >Module1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Module1Module1  5           Module1.ModuleCreationPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Module1     5        N� Title$  Module3Page��5      .��5	      ]� $
��True��6   .+�5
   
   �� -   5        $��Bottom=�5
   ,   $��10q�6D   .��6P   Создать модуль6`   �� 5   
   $
��Left=�6    �� Orientation$ Vertical=�6+   .+�5      �� .��6   Создание модуля6%   �� 5      $ 
Horizontal=�6   .+�5      �� .��6   Название модуля6)   �� 5      -   5         ��Name$
 Name��5      $	��200��6j   ��6(   �� *Module.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6x   5      �� 5      $ 
Horizontal=�6   .+�5      �� .��6   Номер приказа6'   �� 5      -   5        $ Number��5      $	��200��6l   ��6*   �� *Module.Code+$ PropertyChanged=�6z   5      �� 5      $ 
Horizontal=�6   .+�5      �� .��6   '%Длительность(в днях)6.   �� 5      -   5        $ Duration��5      $	��200��6r   ��6,   �� *Module.Duration+$ PropertyChanged=�6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� .��6   Дата реализации6)   (  "System.Windows.Controls.DatePicker  5      -   5          Name$
 Date��5      $	��200��6z      SelectedDate 6+   �� *SelectedDateTime+$ PropertyChanged=�6�   5      �� 5      $ 
Horizontal=�6   .+�5      �� .��6   Источник данных6)   �� 5      -   5        $ Source��5      $	��200��6r   ��6*   �� *Module.InfoSource+$ PropertyChanged=�6�   5       �� 5!      $ 
Horizontal=�6   .+�5"      �� .��6   %#Ответственное лицо6,   �� 5#      -   5         ��Name$ 	Employees��5#      $	��200��6�   ��6.   �� *EmployeesList+ �� SelectedItem 6T   �� *$"Module.ResponsiblePersonNavigation+$ PropertyChanged=�6�   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� .��6   '%Родительский модуль6-   �� 5'      -   5        $ Modules��5'       �� SelectedValuePath$ Id��6P   $	��200��6�   ��6,   �� *ModulesList+	 �� SelectedValue	 6g   �� *Module.ParentModuleId+$ PropertyChanged=�6�   5(      5)      �� 5*   
   $ 
Horizontal=�6   .+�5+      �� $ Vertical=�6   $��	0,0,100,0q�60   .+�5,      �� .��6   Согласованты6&   �� 5-      $ 
Horizontal=�6   .+�5.      �� -	   5        
 ��Name$
 EmplListView��5.       �� SelectionMode$ Multiple=�6[   ��65   �� *EmployeesList+��5/      �� 50      .R�51   "   �� $ Vertical=�6-   .+�52   &   �� ��6,   �� *Id+6E   � 53   &   .+�54   *   �� .��60   	ФИО:67   �� 55   *   ��60   �� *	FirstName+6P   �� 56   *   ��60   �� *
LastName+6O   �� 57   *   ��60   �� *
MiddleName+6Q   58   '   59   #   5:      5<      5=      5>      �� 5?      $ Vertical=�6   .+�5@      �� .��6   Должности6#   �� 5A      $ 
Horizontal=�6   .+�5B      �� -
   5        $
 PosListView��5B      $ Multiple=�6V   ��64   �� *	Positions+��5C      �� 5D      .R�5E   "   �� $ Vertical=�6-   .+�5F   &   �� ��6,   �� *Id+6E   � 5G   &   .+�5H   *   �� ��60   �� *Name+6K   5I   '   5J   #   5K      5M      5N      5O      5P      5Q      5R      