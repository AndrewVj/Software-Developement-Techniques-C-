   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5   	       FinalProject.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalProject     5   	     � Title$  
MainWindow��5   	   $	��640��6   $	��800��6)   .��5	      �  � 	Resources 5
   
      FinalProject.RowConverter   CustomRowConvertor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%&  &	        '��      '�� �     '  7    '�� �    '�� �    '�� �    '	� �    '�� :      5      6    �� 5      " ��6   .�5      ��  � ��$ 14(�6-   �� 5       � ��$ 1q�6+   �� 5       � ��$ Arial)�6/   5      �� 5      " ��6   .�5      ��  � ��$ 14(�6-   �� 5       � ��$ Arial)�6/   �� 5       � ��$ 3q�6+   5      �� 5      "  6   .�5      ��  � ��$ 14(�6-   �� 5       � ��$ Arial)�6/   5!      �� 5"      " ��6   .�5#      ��  � ��$ 14(�6-   �� 5$       � ��$ 24��6+   �� 5%       � ��$ Arial)�6/   �� 5&       � ��$	 160��6*   �� 5'       � ��$ 1q�6+   5(      �� 5)      " ��6   .�5*      ��  � ��$ 14(�6-   �� 5+       � ��$ Arial)�6/   5-      �� 5.      " ��6   .�5/      ��  � ��$ 14(�6-   �� 50       � ��$ 24��6+   �� 51       � ��$ Arial)�6/   �� 52       � ��$	 160��6*   �� 53       � ��$ 1q�6+   54      �� 55      " 	�6   .�56      ��  � ��$ 14(�6-   �� 58       � ��$ Arial)�6/   59      �� 5:      " ��6   .�5;      ��  � ��$ 14(�6-   �� 5<       � ��$ 1q�6+   �� 5=       � ��$ Arial)�6/   5>      5@      .+�5A   
   � $��Center=�6   $	��Top=�6,    � ColumnDefinitions 5B      �� 5C      $	��220 �6#   �� 5D      $	��260 �6#   �� 5E      $	��272 �6#    � RowDefinitions 5H      �� 5I      $
��Auto �6    �� 5J      $
��Auto �6    �� 5K      $
��Auto �6    �� 5L      $
��Auto �6    �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    �� 5O      $
��Auto �6    �� 5P      $
��Auto �6    �� 5Q      $
��Auto �6    �� 5R      $
��Auto �6    �� 5S      $
��Auto �6    �� 5T      $
��Auto �6    �� 5U      $	��200��6    �� 5V      $
��Auto �6    .+�5X      �� -   5         ��Name$ SmileCheckScheduler��5X      $��Smile Check Scheduler��61   $��0��6Q   $��0��6^   $��3��6n   $��Center=�6�   $��Center=�6�   $��18(�6�   $
��Bold"�6�   �� 5Y      -   5        $ 	TodayDate��5Y      $�� ��6'   $��0��62   $��3��6?   $��Right=�6P   $��Center=�6m   $��18(�6�   $
��Bold"�6�   �� 5Z       �� Orientation$ 
Horizontal=�6   $��1��62   $��0��6?   $
��Left=�6O   $��Center=�6k   .+�5[      �� -   5        $ appoinmentSlotsLabel��5[      $��Available Timeslots��66   �� 5\      $��*��6   
���  ��68   5]      �� 5^      -   5        	 ��Name$	 appoinmentSlotsBorder��5^      $��1q�64   $��1��6H   $��1��6V   $
��left=�6f   $��Center=�6�   ._�5_      �� -   5        
 ��Name$
 appoinmentSlots��5_      $
��Left=�64   $��Center=�6O   6j   5a      �� 5b      $ 
Horizontal=�6   $��3��62   $��0��6?   $
��Left=�6O   $��Center=�6k   .+�5c      �� -   5        $ patientName��5c      $��Patient Name��6-   $��3��6D   $��0��6Q   $
��Left=�6a   $��Center=�6}   �� 5d      $��*��6   
���  ��68   5e      �� 5g      -   5        $	 patientNameBorder��5g      $��1q�60   $��3��6D   $��1��6Q   $��Center=�6a   $
��Left=�6|   ._�5h      �� -   5         ��Name$ patientNameInput��5h      $��Center=�65   $��Center=�6R    � ToolTip 6m   ��  �� ElementName$ patientNameInput�� �� Path$) #(Validation.Errors)[0].ErrorContent�.��6�   ��5i      �� 5j      $
 Name�6"    �� UpdateSourceTrigger$ 	LostFocus=�6/    �� ValidationRules 5k      1  +FinalProject.GenericTextFieldValidationRule  5l   "   
   Min$ 2��6G   
   Max$ 50��6O   5n      .��5o   $   5p      5r      �� 5u      $ 
Horizontal=�6   $��4��62   $��0��6?   $
��Left=�6O   $��Center=�6k   .+�5v      �� -	   5        $ patientAgeLabel��5v      $��Patient Age��61   $��4��6G   $��0��6T   $
��Left=�6d   $��Center=�6�   �� 5w      $��*��6   
���  ��68   5x      �� 5z      -
   5        $	 patientAgeBorder��5z      $��1q�6/   $��4��6C   $��1��6P   $
��Left=�6`   $��Center=�6{   ._�5{      �� -   5        $ patientAgeInput��5{      $��Center=�64   $��Center=�6Q    6�   �� $ patientAgeInput��$) #(Validation.Errors)[0].ErrorContent�.��6  ��5|      �� 5}      $	 Age�6"   $ 	LostFocus=�6.    5~      $  FinalProject.AgeValidationRule  5   "   
   Min$ 5��6:   
   Max$	 100��6B   5�      .��5�   $   5�      5�      �� 5�      $ 
Horizontal=�6   $��5��62   $��0��6?   $
��Left=�6O   $��Center=�6k   .+�5�      �� -   5        $ patientPhoneNumberLabel��5�      $��Patient Phone Number��69   $��5��6X   $��0��6e   $
��Left=�6u   $��Center=�6�   �� 5�      $��*��6   
���  ��68   5�      �� 5�      -   5        $	 patientPhoneNumberBorder��5�      $��1q�67   $��5��6K   $��1��6X   $
��Left=�6h   $��Center=�6�   ._�5�      �� -   5        $ patientPhoneNumberInput��5�      $��Center=�6<   $��Center=�6Y    6t   �� $ patientPhoneNumberInput��$) #(Validation.Errors)[0].ErrorContent�.��6�   ��5�      �� 5�      $ PhoneNumber�6"   $ 	LostFocus=�66    5�      ,  &FinalProject.PhoneNumberValidationRule  5�   "   5�      .��5�   $   5�      5�      �� 5�      $ 
Horizontal=�6   $��6��62   $��0��6?   $
��Left=�6O   $��Center=�6k   .+�5�      �� -   5        $ CCNumberLabel��5�      $!��CreditCard Number(16 digit)��6/   $��6��6U   $��0��6b   $
��Left=�6r   $��Bottom=�6�   $��1,0,0,1q�6�   �� 5�      $��*��6   
���  ��68   5�      �� 5�      -   5        $ CCNumber��5�      $
��Left=�6,   $��6��6G   $��1��6T   $��Center=�6e    6�   �� $ CCNumber��$) #(Validation.Errors)[0].ErrorContent�.��6�   ��5�      �� 5�      $ CreditCardNumber�6   $ 	LostFocus=�67    5�      +  %FinalProject.CreditCardValidationRule  5�   "   5�      .��5�   $   5�      �� 5�      -   5         ��Name$ DentalServicesLabelPanel��5�      $ 
Horizontal=�6;   $��7��6T   $��0��6a   $
��Left=�6q   $��Center=�6�   $y�Visible=�6�   .+�5�      �� -   5        $ DentalServicesLabel��5�      $��Dental Services��65   $��7��6O   $��0��6\   $
��Left=�6l   $��Center=�6�   5�      �� 5�      -   5        $ DentalServicesPanel��5�      $��7��66   $��1��6C   $ 
Horizontal=�6S   $
��Left=�6l   $��Center=�6�   $y�Visible=�6�   .+�5�      �� -   5         ��Name$ RoutineCheckUp��5�      $��Routine CheckUp��64   $
��Left=�6N   $��Center=�6i    d� 	IsChecked$
 TrueY�6�   ${�False��6�   �� 5�      -   5        $ ToothExtraction��5�      $��Tooth Extraction��65   $
��Left=�6P   $��Center=�6k   $ FalseY�6�   5�      �� 5�      -   5        $ DentalServicesPanel1��5�      $��7��67   $��2��6D   $ 
Horizontal=�6T   $
��Left=�6m   $��Center=�6�   $y�Visible=�6�   .+�5�      �� -   5        $ Cleaning��5�      $��Cleaning��6.   $
��Left=�6A   $��Center=�6\   $ FalseY�6w   �� 5�      -   5        $ CavityFilling��5�      $��Cavity Filling��63   $
��Left=�6L   $��Center=�6g   $ FalseY�6�   5�      �� 5�      -   5        $ DentalServicesPanel2��5�      $��8��67   $��1��6D   $ 
Horizontal=�6T   $
��Left=�6m   $��Center=�6�   $y�Visible=�6�   .+�5�      �� -   5        $ CosmeticSurgery��5�      $��Cosmetic Surgery��65   $
��Left=�6P   $��Center=�6k   $ FalseY�6�   ${�False��6�   �� 5�      -   5        $ DentalImplants��5�      $��Dental Implants��64   $
��Left=�6N   $��Center=�6i   $ FalseY�6�   ${�False��6�   5�      �� 5�      -   5        $ DentalServicesPanel3��5�      $��8��67   $��2��6D   $ 
Horizontal=�6T   $
��Left=�6m   $��Center=�6�   $y�Visible=�6�   .+�5�      �� -   5        $ BabyToothExtraction��5�      $��Baby Tooth Extraction��69   $
��Left=�6Z   $��Center=�6u   $ FalseY�6�   ${�False��6�   5�      �� 5�      -   5         ��Name$ BookAppointment��5�      $��Book Appointment��6.   $��10��6I   $��1��6W   $
��Left=�6h   $��Bottom=�6�   6�   �� 5�      -   5        $ Message��5�      $�� ��6%   $��11��60   $��0��6?   $��3��6O   $��Center=�6c   $��Center=�6�     5�      -    5          Name$ AllAppointmentsGrid��5�      $	��721��65   $	��200��6A   $
��Left=�6N   $	��Top=�6i      AutoGenerateColumns$ false��6�   $��12��6�   $��0��6�   $��4��6�   $��3��6�      RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6   .�5�      ��  � �� 67   �� $ .� �� 	Converter# [  5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  
IsReadOnly$
 True��6)    	  Header$ Appointment Slot��6;   1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  6U   �� *AppointmentDateTime+  5�      $
 True��6)   $
 Type��6;     6J   �� *PatientType+  5�      $
 Name��6)     67   �� *Patient.Name+  5�      $
 True��6)   $	 Age��6;     6I   �� *Patient.Age+  5�      $ 	Phone No.��6)     6=   �� *Patient.ContactNumber+  5�      $
 True��6)   $ Credit Card No.��6;     6U   �� *Patient.ConcealedCCNumber+  5�      $
 True��6)   $ Servicing operations��6;     6Y   �� *	Patient+5�      �� 5�      $��13��6   $��0��6'   $��3��67   $ 
Horizontal=�6K   $
��Left=�6d   $��Center=�6   .+�5�      �� -!   5        $ ShowAppointments��5�      $��4q�63   $��Show All Appointment��6>   $; 5Show all saved appointment sorted by appointment slot��5�      6V   �� 5�      -"   5        $ Delete��5�      $��4q�6)   $��Delete��64   $) #Delete selected appointment in grid��5�      6D   �� 5�      -#   5        $ Update��5�      $��4q�6)   $��Update��64   $) #Update selected appointment in grid��5�      6C   �� 5�      $��Filter by patient type��6   $��13��69   $��2��6G   $
��Left=�6W   $��Center=�6r   �� 5�      -$   5        $)
 #DataGridFilterCriteriaByPatientType��5�      $��4q�6H   $��13��6S   $��2��6a   $��Right=�6q   $��Center=�6�   6�   5�      5�      5�      5�      