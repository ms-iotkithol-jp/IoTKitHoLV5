### Input 
edgeHubInput  ← ＋ストリーム入力の追加 - Edge Hub 
### Output 
edgeHubOutput ← ＋追加 - Edge Hub
### Query
```sql
WITH accelScaleCalc  AS (
    SELECT *,
     SQRT( accel.x * accel.x + accel.y * accel.y + accel.z * accel.z) as accelScale
    FROM [edgeHubInput]
)
SELECT
    timeCreated,
    AnomalyDetection_SpikeAndDip(accelScale, 80, 120, 'spikes')
    OVER(LIMIT DURATION(second, 60)) AS SpikeAndDipScores
INTO
    [edgeHubOutput]
FROM
    [accelScaleCalc]
```