using Xunit;
using Proyect_de_Redes_version_1._0.Error_Detection;
using Proyect_de_Redes_version_1._0;

namespace UnitTest
{
    public class ErrorDetectionTests
    {
        [Fact]
        public void TestVRCEncodeFrame()
        {
            Frame frame = new Frame("1101", "0000", "2010");

            VRC detecter = new VRC();

            detecter.CodeFrame(frame);

            Assert.Equal("01001111", frame.VerifBits);
            Assert.Equal("00001000", frame.VerifSize);
        }
    }
}