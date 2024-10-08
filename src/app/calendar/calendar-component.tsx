'use client';

import * as perfumeRepo from "@/db/perfume-repo";
import * as perfumeWornRepo from "@/db/perfume-worn-repo";
import React, { useEffect, useState } from "react";
import { Bar } from 'react-chartjs-2';

import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { Tag } from "@prisma/client";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);


export const dynamic = 'force-dynamic'

export interface CalendarPageProps {
    perfumes: perfumeRepo.PerfumeWithTagDTO[],
    perfumesWorn: perfumeWornRepo.WornWithPerfume[],
    allTags: Tag[],
}


export default function CalendarComponent({ perfumes, perfumesWorn, allTags }: CalendarPageProps) {

    //TODO: all this stuff should not happen on the frontend
    interface TagStat {
        name: string;
        color: string;
        mls: number;
        wornCount: number;
    }

    type TagStats = Record<string, TagStat>;

    type DayStats = Record<string, TagStats>;


    const datasets: {label: string, data: number[], backgroundColor: string}[] = [];

    const [dailyStats, setMonthlyStats] = useState<DayStats>({});

    useEffect(() => {
        const stats: DayStats = {};
        
        perfumesWorn.forEach(pw => {
            const date = new Date(pw.wornOn);
            const dateKey = date.toISOString().split('T')[0];
            
            if (!stats[dateKey]) {
                stats[dateKey] = {};
            }

            const perfume = perfumes.find(p => p.perfume.id === pw.perfume.id);
            if (perfume && perfume.perfume.rating >= 8) {
                perfume.tags.forEach(tag => {
                    if (!stats[dateKey][tag.tag]) {
                        stats[dateKey][tag.tag] = {
                            name: tag.tag,
                            color: tag.color,
                            mls: 0,
                            wornCount: 0
                        };
                    }
                    //stats[dateKey][tag.tag].mls += perfume.perfume.ml;
                    stats[dateKey][tag.tag].wornCount += 1;
                });
            }
        });

        setMonthlyStats(stats);
    }, [perfumes, perfumesWorn]);

    allTags.map(x => datasets.push({
        label: x.tag,
        data: [0,0,0,0,0,0,0],
        backgroundColor: x.color
    }));

    const labels: Set<string> = new Set<string>();
    let day = 0;
    Object.values(dailyStats).map(x => {
        Object.values(x).map(tags => {
            datasets.filter(f => f.label === tags.name).map(dataSet => dataSet.data[day] += tags.wornCount)
            labels.add(tags.name);
        })
        day++;
    });

    const data = {
        labels: Object.keys(dailyStats),
        datasets: datasets.filter(x => labels.has(x.label))
    };


    const options = {
          plugins: {
            title: {
              display: true,
              text: 'Notes per date'
            },
          },
          responsive: true,
          maintainAspectRatio: false,
          indexAxis: 'y' as const,
          scales: {
            x: {
              stacked: true,
            },
            y: {
              stacked: true
            }
          }
    };
      

    return (
        <div style={{ height: '600px' }}>
                <Bar data={data} options={options} />
        </div>
    );
}