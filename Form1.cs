using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Possum
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Physiological score
            Dictionary<string, int> age = new Dictionary<string, int>
            {
                { ">=60", 1 },
                { "61-70", 2 },
                { ">=71", 4 }
            };

            Dictionary<string, int> cardiac = new Dictionary<string, int>
            {
                { "No failure", 1 },
                { "Diuretic, digoxin or angina/hypertension meds", 2 },
                { "Peripheral edema, warfarin, or borderline cardiomegaly on chest X-ray (CXR)", 4 },
                { "Raised jugular venous pressure, or cardiomegaly on CXR", 8 }
            };

            Dictionary<string, int> respiratory = new Dictionary<string, int>
            {
                { "No dyspnea", 1 },
                { "Exertional dyspnea or mild COPD on CXR", 2 },
                { "Limiting dyspnea or moderate COPD on CXR", 4 },
                { "Dyspnea at rest or fibrosis/consolidation on CXR", 8 }
            };

            Dictionary<string, int> sbp = new Dictionary<string, int>
            {
                { "<=89", 8 },
                { "90-99", 4 },
                { "100-109", 2 },
                { "110-130", 1 },
                { "131-170", 2 },
                { ">=171", 4 }
            };

            Dictionary<string, int> hr = new Dictionary<string, int>
            {
                { "<=39", 8 },
                { "40-49", 2 },
                { "50-80", 1 },
                { "81-100", 2 },
                { "101-120", 4 },
                { ">=121", 8 }
            };

            Dictionary<string, int> glasgow = new Dictionary<string, int>
            {
                { "15", 1 },
                { "12-14", 2 },
                { "9-11", 4 },
                { "<=8", 8 }
            };

            Dictionary<string, int> hemoglobin = new Dictionary<string, int>
            {
                { "<=99 / <=9.9", 8 },
                { "100-114 / 10-11.4", 4 },
                { "115-129 / 11-12.9", 2 },
                { "130-160 / 13-16", 1 },
                { "161-170 / 16.1-17.0", 2 },
                { "171-180 / 17.1-18.0", 4 },
                { ">=181 / >=18.1", 8 }
            };

            Dictionary<string, int> wbc = new Dictionary<string, int>
            {
                { "<=3", 4 },
                { "3.1-4.0", 2 },
                { "4.1-10.0", 1 },
                { "10.1-20.0", 2 },
                { ">=20.1", 4 }
            };

            Dictionary<string, int> bun = new Dictionary<string, int>
            {
                { "<=45 / <=7.5", 1 },
                { "46-60 / 7.6-10.0", 2 },
                { "61-90 / 10.1-15.0", 4 },
                { ">90 / >15.0", 8 }
            };

            Dictionary<string, int> sodium = new Dictionary<string, int>
            {
                { "<=125", 8 },
                { "126-130", 4 },
                { "131-135", 2 },
                { ">=136", 1 }
            };

            Dictionary<string, int> potassium = new Dictionary<string, int>
            {
                { "<=2.8", 8 },
                { "2.9-3.1", 4 },
                { "3.2-3.4", 2 },
                { "3.5-5.0", 1 },
                { "5.1-5.3", 2 },
                { "5.4-5.9", 4 },
                { ">=6.0", 8 }
            };

            Dictionary<string, int> ecg = new Dictionary<string, int>
            {
                { "Normal", 1 },
                { "Atrial fibrillation (HR 60-90)", 4 },
                { "Any other abnormal rhythm, or 5 ectopic beats/min, Q waves or ST/T wave changes", 8 }
            };

            //Operative severity score
            Dictionary<string, int> operative_severity = new Dictionary<string, int>
            {
                { "Minor", 1 },
                { "Moderate (appendectomy, cholecystectomy, mastectomy, transurethral resection of the prostate)", 2 },
                { "Major (laparotomy, bowel resection, cholecystectomy w choledochotomy, peripheral vascular procedure or major amputation)", 4 },
                { "Major+ (aortic procedure, abdominoperineal resection, pancreatic or liver resection, esophagogastrectomy)", 8 }
            };

            Dictionary<string, int> number_of_procedures = new Dictionary<string, int>
            {
                { "1", 1 },
                { "2", 4 },
                { ">=2", 8 }
            };

            Dictionary<string, int> est_blood_loss = new Dictionary<string, int>
            {
                { "<100", 1 },
                { "101-500", 2 },
                { "501-999", 4 },
                { ">=1000", 8 }
            };

            Dictionary<string, int> peritoneal_soiling = new Dictionary<string, int>
            {
                { "None", 1 },
                { "Minor (serous fluid)", 2 },
                { "Local pus", 4 },
                { "Free bowel content, pus or blood", 8 }
            };

            Dictionary<string, int> presence_of_malignancy = new Dictionary<string, int>
            {
                { "None", 1 },
                { "Primary only", 2 },
                { "Lymph node mets", 4 },
                { "Distant mets", 8 }
            };

            Dictionary<string, int> mode_of_surgery = new Dictionary<string, int>
            {
                { "Elective", 1 },
                { "Emergency (within 24h), resuscitation >2h possible", 4 },
                { "Emergency (within 2h)", 8 }
            };


            //Dictionary-Combobox binding invocation
            BindComboBox(comboAge, age);
            BindComboBox(comboCardiac, cardiac);
            BindComboBox(comboRespiratory, respiratory);
            BindComboBox(comboSBP, sbp);
            BindComboBox(comboHR, hr);
            BindComboBox(comboGlasgow, glasgow);
            BindComboBox(comboHemoglobin, hemoglobin);
            BindComboBox(comboWBC, wbc);
            BindComboBox(comboBUN, bun);
            BindComboBox(comboSodium, sodium);
            BindComboBox(comboPotassium, potassium);
            BindComboBox(comboECG, ecg);
            BindComboBox(comboOpSev, operative_severity);
            BindComboBox(comboNoOfProc, number_of_procedures);
            BindComboBox(comboEstBloodLoss, est_blood_loss);
            BindComboBox(comboPeritSoil, peritoneal_soiling);
            BindComboBox(comboPresOfMalig, presence_of_malignancy);
            BindComboBox(comboModeOfSurg, mode_of_surgery);


        }

        //Dictionary-Combobox binding
        private void BindComboBox(ComboBox comboBox, Dictionary<string, int> items)
        {
            comboBox.DataSource = new BindingSource(items, null);
            comboBox.DisplayMember = "Key";
            comboBox.ValueMember = "Value";
        }

        //Morbidty and Mortality calculation
        public static double CalculateMorbidity(int physiologicalScore, int operationSeverityScore)
        {
            double exponent = -(-5.91 + (0.16 * physiologicalScore) + (0.19 * operationSeverityScore));
            return 1 / (1 + Math.Exp(exponent));
        }
        public static double CalculateMortality(int physiologicalScore, int operationSeverityScore)
        {
            double exponent = -(-7.04 + (0.13 * physiologicalScore) + (0.16 * operationSeverityScore));
            return 1 / (1 + Math.Exp(exponent));
        }

        private void buttonCalc_MouseClick(object sender, MouseEventArgs e)
        {
            int physiologicalScore = 0;
            int operationSeverityScore = 0;
            physiologicalScore += ((KeyValuePair<string, int>)comboAge.SelectedItem).Value + ((KeyValuePair<string, int>)comboCardiac.SelectedItem).Value + ((KeyValuePair<string, int>)comboRespiratory.SelectedItem).Value + ((KeyValuePair<string, int>)comboSBP.SelectedItem).Value + ((KeyValuePair<string, int>)comboHR.SelectedItem).Value + ((KeyValuePair<string, int>)comboGlasgow.SelectedItem).Value + ((KeyValuePair<string, int>)comboHemoglobin.SelectedItem).Value + ((KeyValuePair<string, int>)comboWBC.SelectedItem).Value + ((KeyValuePair<string, int>)comboBUN.SelectedItem).Value + ((KeyValuePair<string, int>)comboSodium.SelectedItem).Value + ((KeyValuePair<string, int>)comboPotassium.SelectedItem).Value + ((KeyValuePair<string, int>)comboECG.SelectedItem).Value;
            operationSeverityScore += ((KeyValuePair<string, int>)comboOpSev.SelectedItem).Value + ((KeyValuePair<string, int>)comboNoOfProc.SelectedItem).Value + ((KeyValuePair<string, int>)comboEstBloodLoss.SelectedItem).Value + ((KeyValuePair<string, int>)comboPeritSoil.SelectedItem).Value + ((KeyValuePair<string, int>)comboPresOfMalig.SelectedItem).Value + ((KeyValuePair<string, int>)comboModeOfSurg.SelectedItem).Value;
            double morbidityRisk = CalculateMorbidity(physiologicalScore, operationSeverityScore);
            double mortalityRisk = CalculateMortality(physiologicalScore, operationSeverityScore);
            mortality.Text = "Mortality: " + $"{mortalityRisk:P2}";
            morbidity.Text = "Morbidity: " + $"{morbidityRisk:P2}";
        }
    }
}
