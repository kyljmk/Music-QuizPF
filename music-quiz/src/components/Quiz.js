import React, { useState, useEffect } from 'react'
import { createAPIEndpoint, ENDPOINTS } from '../api'
import useStateContext from './useContext'
import { Card, CardContent, CardHeader, List, ListItemButton, Typography, Box, LinearProgress } from '@mui/material'
import { useNavigate } from 'react-router'

export default function Quiz() {

    const [questions, setQuestions] = useState([])
    const [questionIndex, setQuestionIndex] = useState(0)
    const { context, setContext } = useStateContext()
    const navigate = useNavigate()

    useEffect(() => {
      setContext({
          selectedOptions: []
      })
      createAPIEndpoint(ENDPOINTS.question)
          .fetch() 
          .then(res => {
              setQuestions(res.data)
          })

      return
  }, [])

    const updateAnswer = (questionId, optionIndex) => {
        const temp = [...context.selectedOptions]
        temp.push({
            questionId,
            selected: optionIndex
        })
        if (questionIndex < 4) {
            setContext({ selectedOptions: [...temp] })
            setQuestionIndex(questionIndex + 1)
        }
        else {
            setContext({ selectedOptions: [...temp], })
            navigate("/result")
        }
    }

    return (
        questions.length != 0
            ? <Card
                sx={{
                    maxWidth: 640, mx: 'auto', mt: 5,
                    '& .MuiCardHeader-action': { m: 0, alignSelf: 'center' }
                }}>
                <CardHeader
                    title={'Question ' + (questionIndex + 1) + ' of 5'} />
                <Box>
                    <LinearProgress variant="determinate" value={(questionIndex + 1) * 100 / 5} />
                </Box>
                <CardContent>
                    <Typography variant="h6">
                        {questions[questionIndex].questionBody}
                    </Typography>
                    <List>
                        {questions[questionIndex].options.map((item, index) =>
                            <ListItemButton disableRipple key={index} onClick={() => updateAnswer(questions[questionIndex].questionId, index)}>
                                <div>
                                    <b>{String.fromCharCode(65 + index) + " . "}</b>{item}
                                </div>
                            </ListItemButton>
                        )}
                    </List>
                </CardContent>
            </Card>
            : null
    )
}