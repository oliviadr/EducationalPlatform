   M S B A M L   `   `   `  ����P  LPlatformaEducationala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PlatformaEducationala.ViewModels PlatformaEducationala.ViewModels  5   	   S.clr-namespace:PlatformaEducationala.Converters PlatformaEducationala.Converters  5   	   I)clr-namespace:PlatformaEducationala.ViewsPlatformaEducationala.Views  5   	   )    #PlatformaEducationala.Views.Materii   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >ctx.clr-namespace:PlatformaEducationala.ViewModels     5   	   Bconvert.clr-namespace:PlatformaEducationala.Converters     5   	   ;local)clr-namespace:PlatformaEducationala.Views     5   	     � Title$  Materii��5
   	   $	��600��6   $	��700��6&    � DataContext 5      0   *PlatformaEducationala.ViewModels.SubjectVM  5   
    � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  DataGridStyle&   System.Windows.Controls.DataGrid*  $System.Windows.Controls.DataGridCell	 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader  
LabelStyle  ComboBoxStyle
 �� StringFormat �� Path  DatePickerStyle(  "System.Windows.Controls.DatePicker  CheckBoxStyle��%�  &	        &	 �    &	 b    &	 !	    &	 �    &	 �    �� 5   
   " ��6$   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 15q�6'   �� 5       � ��$ 14(�6)   �� 5       � �� �#003B736+   �� 5       � ��
 �����6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6(   �� 5       � ��$
 Left=�64   �� 5       � ��$ Center=�62    5      P� 5       �@J�IsMouseOver . . �5      ��  � �� �	#FF00224163   5      P� 5        � �� . . �5!      ��  � �� �#106EBE63   5"      5$      �� 5'   
   "  6&   .�5(      ��  � �� �#F1F1F16+   �� 5)       � �� �#CCCCCC6,   �� 5*       � ��$ 1q�60   �� 5+       �@ RowBackground �#FFFFFF6.   �� 5,       �@ GridLinesVisibility$
 None=�64   �� 5-       � ��$ 12(�6)   �� 5.       �@ CanUserResizeColumns .  65   �� 5/       �@ AutoGenerateColumns .  64   �� 50        �@ RowDetailsVisibilityMode$ VisibleWhenSelected=�69   �� 51       �@ 	CellStyle 52      �� 53      "  6   .�54      ��  � ��
 ���� 68   �� 55       � ��$ 0q�6<   �� 56       � �� �#33333367   �� 57       � ��$ 5q�64   �� 58       � �� 59      �� 5:   "   "	  62   .R�5;   &   � #��z��6+   .+�5<   *   �� $��Center=�6;   5=   '   5>   #   5@       5A      P� 5B       �@ 
IsSelected . . �5C   "   ��  � �� �	#FF99C8F76?   �� 5D   "    � ��
 �   �6?   5E      5G      5I      �� 5J       �@ ColumnHeaderStyle 5K      �� 5L      "  6   .�5M      ��  � �� �#003B7367   �� 5N       � ��
 �����67   �� 5O       � ��$
 Bold"�67   �� 5P       � ��$
 Left=�6G   �� 5Q       � ��$ Center=�6E   �� 5R       � ��$ 10q�64   5S      5U       5V      P� 5W       �@��
IsSelected . . �5X      ��  � �� �	#FF00224163   �� 5Y       � ��
 �����63   5Z      5\      �� 5e   
   " ��6#   .�5f      ��  � ��$	 150��6&   �� 5g       � ��$ 15(�6)   �� 5h       � �� �#3333336+   �� 5i       � ��$ Center=�62   5j      �� 5m   
   " ��6&   .�5n      ��  � ��$	 200��6&   �� 5o       � ��$ 14(�6)   �� 5p       � ��$ Center=�62   �� 5q       � �� �#3333336+   �� 5r       � ��$ 5q�6(   �� 5s       � �� �#E5E5E56+   �� 5t       � �� �#CCCCCC6,   �� 5u       � ��$ 1q�60   �� 5v       �@��SelectedValuePath$ Item2��62   �� 5w       � �� 5x      �� 5y      .R�5z      �� ��5{      `� 5|   "   $
 
{0} -> {1}��6/   .1�5}   &   �� $ Item1�6.   �� 5~   &   $ Item2�6.   5   #   5�      5�      5�      5�      �� 5�   
   "  6(   .�5�      ��  � ��$	 200��6&   �� 5�       � ��$ 14(�6)   �� 5�       � ��$ Center=�62   �� 5�       � �� �#3333336+   �� 5�       � ��$ 5q�6(   �� 5�       � �� �#E5E5E56+   �� 5�       � �� �#CCCCCC6,   �� 5�       � ��$ 1q�60   5�      �� 5�   
   " ��6&   .�5�      ��  � ��$ 14(�6)   �� 5�       � ��$ Center=�62   �� 5�       � �� �#3333336+   5�      5�      .��5�      ��  5�   
   7  1PlatformaEducationala.Converters.ConvertorSubject  SubjectConvert��%   &	         5�      6'   5�      .+�5�   
   � $��Center=�6   $��Center=�61   .+�5�      �� $��Insert��6   #��[  6&   $��15q�6K   $	��100��6W   $��30��6c   ��5�      �� *ComandaInserare+��5�      `� 5�       `� 	Converter# [ 6#   .1�5�      ��  �� ElementName$ txtNume��6"   $
 Text�68   �� 5�      $ txtIdTeacher��6"   $
 Text�6=   �� 5�      $ 
txtAreTeza��6"   $ 	IsChecked�6;   �� 5�      $ txtAnStudiu��6"   $
 Text�6<   5�      5�      �� 5�      $��Update��6   #��[  6&   $��15q�6K   $	��100��6W   ��6c   �� *ComandaActualizare+��5�      �� $ gridMaterii��$ SelectedItem��� 5�      $��Delete��6   #��[  6&   $��15q�6K   $	��100��6W   ��6c   �� *ComandaStergere+��5�      �� $ gridMaterii��$ SelectedItem�5�      � 5�   
   $��0,15,0,0q�6   5�      � 5�   
   $��0,15,0,0q�6   $��Center=�6&   $��Center=�6C   .+�5�      �� $	��150��6   $��15(�6    .��6.   Name:65   �� 5�      -   5        $��txtNume��5�      $	��200��6%   ��61   �� $ gridMaterii��$ SelectedItem.Nume� �� UpdateSourceTrigger$ PropertyChanged=�5�      � 5�   
   $��0,15,0,0q�6   $��Center=�6&   $��Center=�6C   .+�5�      �� $	��150��6   $��15(�6    .��6.   Name + Id Teacher:6B   �� 5�      -   5        $��txtIdTeacher��5�      $	��200��6+    �� SelectedValuePath$ Item2��5�      ��5�   7   �� *ListaIdTeacheri+ �� SelectedValue 5�      �� $ gridMaterii��$ SelectedItem.IdTeacher�5�      5�      � 5�   
   $��0,15,0,0q�6   $��Center=�6&   $��Center=�6C   .+�5�      �� $	��150��6   $��15(�6    .��6.   Has Thesis:6;   �� 5�      -   5        $��
txtAreTeza��5�      $	��200��6)   $��Center=�65   $��Center=�6R   $��30��5�   R    d� 	IsChecked 5�   m   �� $ gridMaterii��$ SelectedItem.AreTeza�$ PropertyChanged=�5�   R   5�      � 5�   
   $��0,15,0,0q�6   $��Center=�6&   $��Center=�6C   .+�5�      �� $	��150��6   $��15(�6    .��6.   Study Year:6;   �� 5�      -   5        $��txtAnStudiu��5�      $	��200��6)   ��65   �� $ gridMaterii��$ SelectedItem.AnStudiu�$ PropertyChanged=�5�        5�   
   -   5        $��gridMaterii��5�      #��[ 6&   $��Center=�6M   $��Center=�6j   $��0,15,0,0q�6�      AutoGenerateColumns .  $	��250��5�         
IsReadOnly . $��Visible=�5�      ��5�       �� *ListaSubject+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 63   �� *Nume+  5�      $ 
Id Teacher��6%    69   �� *	IdTeacher+  5�      $ 	Is Thesis��6%    68   �� *	AreTeza+  5�      $ 
Study Year��6%    69   �� *
AnStudiu+5�      5�      5�      