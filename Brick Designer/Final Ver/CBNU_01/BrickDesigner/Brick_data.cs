using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrickDesigner
{
    public class Brick_data
    {
        // 브릭 이름
        public string str_brick_name;

        // 브릭 설명
        public string str_brick_desc;

        // 브릭 타입
        public string str_brick_type;

        // 서브 브릭 정보
        public SortedList<int, Brick_sub_data> sl_subpart_list;

        // 최종 클로닝 정보
        public SortedList<int, Brick_sub_data> sl_cloning_list;

        // 브릭 최종 시퀀스
        // 클로닝 하면 최종 시퀀스 처리
        // 취소하면 null
        public string str_sequence;

        // 서브브릭 시퀀스
        // 브릭을 스칼시키면 처리
        //public string str_sub_sequence;

        public Brick_data()
        {
            sl_subpart_list = new SortedList<int, Brick_sub_data>();
            sl_cloning_list = new SortedList<int, Brick_sub_data>();
            //str_brick_name = "";
        }

        public void cancel_scar()
        {
            foreach (Brick_sub_data bsd in sl_subpart_list.Values)
            {
                if (bsd.part_type == "Scar")
                {
                    bsd.part_name = "Scar";
                    bsd.part_seq = "";
                }
            }
        }
    }
}
