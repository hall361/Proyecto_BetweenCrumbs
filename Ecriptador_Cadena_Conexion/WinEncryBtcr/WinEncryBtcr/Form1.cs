using static WinEncryBtcr.Secural;

namespace WinEncryBtcr
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEjecutarEnc_Click(object sender, EventArgs e)
        {
            try
            {
                AesReturn aes = new AesReturn();
                RtxtResultado.Text = aes.CreateKey(TxtTextoEncrypt.Text);
            }
            catch (Exception ex)
            {

                RtxtResultado.Text = ex.Message;
            }

        }

        private void BtnEjecutarDec_Click(object sender, EventArgs e)
        {
            try
            {
                AesReturn aes = new AesReturn();
                RtxtResultado.Text = aes.DecryptKey(TxtTextoEncrypt.Text);
            }
            catch (Exception ex)
            {

                RtxtResultado.Text = ex.Message;
            }
        }

        private void BtnEjecutarConSt_Click(object sender, EventArgs e)
        {
            try
            {
                AesReturn aes = new AesReturn();
                RtxtResultado.Text = aes.CreateConnectionKey(TxtTextoEncrypt.Text);
            }
            catch (Exception ex)
            {

                RtxtResultado.Text = ex.Message;
            }
        }

        private void BtnEjecutarDecConSt_Click(object sender, EventArgs e)
        {
            try
            {
                AesReturn aes = new AesReturn();
                RtxtResultado.Text = aes.ConnectionKey(TxtTextoEncrypt.Text);
            }
            catch (Exception ex)
            {

                RtxtResultado.Text = ex.Message;
            }
        }
    }
}
