   M S B A M L   `   `   `  ���� F  BAssignment5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment5Assignment5      Assignment5.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Assignment5       � Title$  
MainWindow��$	��450��$	��800��.���  � 	Resources    Assignment5.RowConverter   MyConverter��%   &	          .+��� -    ��Name$ YearOfMakeLabel��$��Year of make:��$
��Left=�$��7,44,0,0q�$	��Top=�$��Arial Black)�$��14(��� -    ��Name$ YearOfMakeTextBox��$
��Left=�$��
207,47,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��130��$��14(��� -   $ ManufacturingCompanyLabel��$��Manufacturing company: ��$
��Left=�$��7,80,0,0q�$	��Top=�$��Arial Black)�$��14(��� -   $! ManufacturingCompanyTextBox��$
��Left=�$��
207,83,0,0q�$
 Wrap=�$	��Top=�$	��130��$��14(��� -   $ VechicleModelLabel��$��Model:��$
��Left=�$��	7,113,0,0q�$	��Top=�$��Arial Black)�$��14(��� -   $ VehicleModelTextBox��$
��Left=�$��207,116,0,0q�$
 Wrap=�$	��Top=�$	��130��$��14(��� -   $ CreditCardLabel��$��Credit card number: ��$
��Left=�$��	7,149,0,0q�$	��Top=�$��Arial Black)�$��14(��� -   $ CreditCardTextBox��$
��Left=�$��207,152,0,0q�$
 Wrap=�$	��Top=�$	��130��$��14(��� -	   $ VehicleTypeLabel��$��Vehicle type:��$
��Left=�$��	7,186,0,0q�$	��Top=�$��Arial Black)�$��14(��� -
    ��Name$ VehicleListComboBox��$
��Left=�$��207,189,0,0q�$	��Top=�$	��120���� -   $ AppointmentsLabel��$��Pick Appointment:��$
��Left=�$��	7,238,0,0q�$	��Top=�$��Arial Black)�$��14(��� -   $ AppointmentsListComboBox��$
��Left=�$��207,241,0,0q�$	��Top=�$	��120���� -    ��Name$ BookAppointmentButton��$��Book Appointment��$
��Left=�$��
11,324,0,0q�$	��Top=� J� RenderTransformOrigin$ -2.17,0.052&�$��Arial Black)�$��14(��� -   $ ProcessAppointmentButton��$��Process Appointments��$
��Left=�$��
11,361,0,0q�$	��Top=�$ -2.17,0.052&�$��Arial Black)�$��14(��� $��Enter Vehicle Details:��$
��Left=�$��7,13,0,0q�$	��Top=�$ -2.17,0.052&�$��Arial Black)�$��14(�&   System.Windows.Controls.DataGrid  -     Name$ 
MyDataGrid��	   AutoGenerateColumns$	 false��$��348,45,10,170q����� 
 �� Path$
 DisplayAppointments�   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value �� $
 .� �� 	Converter# [     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Slot��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *SlotNo+  $
 Time�� �� *AppointmentTime+  $
 Type�� �� *VehicleType+  $
 Year�� �� *CustVehicleYearOfMake+  $ Company�� �� *CustVehicleCompany+  $ Model�� �� *CustVehicleModel+  $ 
CreditCard�� �� *CustVehicleSecureCreditCardNo+  $ Services�� �� *
Services+�� -   $ SearchByYearButton��$��Search��$
��Left=�$��348,288,0,0q�$	��Top=�$ -2.17,0.052&�$��Arial Black)�$��14(��� -   $ SearchByYearTextBox��$
��Left=�$��207,288,0,0q�$
 Wrap=�$	��Top=�$	��130��$��14(��� -   $ SearchLabel��$��Enter the year to search:��$
��Left=�$��	6,285,0,0q�$	��Top=�$��Arial Black)�$��14(��� -   $ SaveToFileButton��$��
SaveToFile��$
��Left=�$��229,341,0,0q�$	��Top=�$ -2.17,0.052&�$��Arial Black)�$��14(�