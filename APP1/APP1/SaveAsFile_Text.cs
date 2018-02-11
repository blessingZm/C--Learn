using System;
using System.Collections.Generic;
using cma.cimiss.client;
using cma.cimiss;

namespace StaElemStatAPI
{
    /*
     * 客户端调取，站点要素统计，存储为txt格式
     */
    class SaveAsFile_TEXT
    {
        public String GetResults(String interfaceid, String datacode, String elements,
            String stdt, String endt, String stid, String resultfile)
        {
            /* 1. 定义client对象 */
            DataQueryClient client = new DataQueryClient();
            /* 2. 调用方法的参数定义，并赋值 */
            /* 2.1 用户名&密码 */
            string userId = "BCWH_BFYG_YCMUSIC";
            string pwd = "yicqxj57461";
            /* 2.2 接口ID */
            string interfaceId = interfaceid;
            /* 2.3 接口参数，多个参数间无顺序 */
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                // 必选参数
                { "dataCode", String.Format("{0}", datacode) },
                { "elements", String.Format("{0}", elements) },
                { "timeRange", String.Format( "[{0},{1}]", stdt, endt) },
                { "staIds", String.Format("{0}",stid) }
            };
            /* 2.4 返回文件的格式 */
            string dataFormat = "text";
            /* 2.5 文件的本地全路径 */
            string savePath = resultfile;
            /* 2.6 返回文件的描述对象 */
            RetFilesInfo retFilesInfo = new RetFilesInfo();

            /* 3. 调用接口 */
            String result_message;
            try
            {
                //初始化接口服务连接资源
                client.initResources();
                //调用接口
                int rst = client.callAPI_to_saveAsFile(userId, pwd, interfaceId, param, dataFormat, savePath, retFilesInfo);
                if (rst == 0)
                { //正常返回
                    result_message = "调用CIMISS接口成功，文件下载完成！";
                }
                else
                { //异常返回
                    result_message = String.Format("调用CIMISS接口成功，但 {0} 文件下载失败，错误码：{0}", savePath, rst);
                }
            }
            catch (Exception)
            {
                //异常输出
                result_message = String.Format("调用CIMISS接口失败");
            }
            finally
            {
                //释放接口服务连接资源
                client.destroyResources();
            }
            return result_message;
        }
    }
}
