using System;
using System.Configuration;
using System.Linq;
using System.Timers;
using InternalSource;
using ExternalSource;


namespace SynchronizationService
{
    public class SyncEngine
    {

        private System.Timers.Timer timer;
        private int minuteIntervalNow = 0;
        private int executionTime = 0;

        private void LoadConfiguration()
        {
            this.executionTime = Convert.ToInt32(ConfigurationManager.AppSettings["executionTime"]); ;
        }


        public void StartService_Click(object sender, EventArgs e)
        {
            this.LoadConfiguration();







            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += new ElapsedEventHandler(TimerEvent);
            timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["intervaloEjecucion"]);
            timer.Enabled = true;
        }

        public void StopService_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            timer.Stop();
            //logger.Info("Stop Service", ConfigurationManager.AppSettings["logPath"]);
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            this.minuteIntervalNow++;
            if (this.minuteIntervalNow >= 1440)
            {
                this.minuteIntervalNow = 0;
            }

            if (this.minuteIntervalNow != this.executionTime) {
                return;
            }

            using (ExternalSource.ExternalContext externalContext = new ExternalSource.ExternalContext())
            {
                using (InternalSource.IntenalContext internalContext = new InternalSource.IntenalContext())
                {
                    var comprometidasExternalList = externalContext.TBL_INV_NP_COMPROMETIDAS_N.ToList();

                    foreach (var item in comprometidasExternalList)
                    {
                        internalContext.TBL_INV_NP_COMPROMETIDAS_N.Add(new InternalSource.TBL_INV_NP_COMPROMETIDAS_N()
                        {
                            fecha_actualizacion = item.fecha_actualizacion,
                            id_alm_ent = item.id_alm_ent,
                            id_estado = item.id_estado,
                            number_1 = item.number_1,
                            number_2 = item.number_2,
                            org_lvl_child = item.org_lvl_child,
                            qty_pend = item.qty_pend,
                            sku_id = item.sku_id.ToUpper(),
                            sticker = item.sticker,
                            vchar_1 = item.vchar_1,
                            vchar_2 = item.vchar_2,
                        });

                        internalContext.SaveChanges();
                    }

                    var despachadasExternalList = externalContext.TBL_INV_CO_DESPACHADAS_N.ToList();

                    foreach (var item in despachadasExternalList)
                    {
                        internalContext.TBL_INV_CO_DESPACHADAS_N.Add(new InternalSource.TBL_INV_CO_DESPACHADAS_N()
                        {
                            fecha_actualizacion = item.fecha_actualizacion,
                            co_desp = item.co_desp,
                            item_name = item.item_name,
                            number_1 = item.number_1,
                            number_2 = item.number_2,
                            vchar_1 = item.vchar_1,
                            vchar_2 = item.vchar_2,
                            whse = item.whse
                        });

                        internalContext.SaveChanges();
                    }

                    var ubicacionExternalList = externalContext.TBL_INV_UBICACIONES_N.ToList();

                    foreach (var item in ubicacionExternalList)
                    {
                        internalContext.TBL_INV_UBICACIONES_N.Add(new InternalSource.TBL_INV_UBICACIONES_N()
                        {
                            fecha_actualizacion = item.fecha_actualizacion,
                            id_item = item.id_item,
                            number_2 = item.number_2,
                            number_1 = item.number_1,
                            vchar_1 = item.vchar_1,
                            whse = item.whse,
                            vchar_2 = item.vchar_2,
                            on_hand_qty = item.on_hand_qty,
                            prd_lvl_child = item.prd_lvl_child,
                            sku_id = item.sku_id,
                            ubicacion = item.ubicacion,
                            wms_locn_id = item.wms_locn_id,
                        });

                        internalContext.SaveChanges();
                    }



                }

            }
        }


    }
}
