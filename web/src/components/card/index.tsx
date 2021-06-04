import { makeStyles } from '@material-ui/core/styles'
import Card from '@material-ui/core/Card'
import CardContent from '@material-ui/core/CardContent'
import Typography from '@material-ui/core/Typography'

const useStyles = makeStyles({
  root: {
    minWidth: 275,
    margin: 10,
  },
  bullet: {
    display: 'inline-block',
    margin: '0 2px',
    transform: 'scale(0.8)',
  },
  title: {
    fontSize: 14,
  },
  pos: {
    fontSize: 30,
    marginTop: 25,
    marginBottom: 5,
  },
})

export default function CustomCard(props: { titulo: any; valor: any }) {
  const classes = useStyles()
  const { titulo, valor } = props

  return (
    <Card className={classes.root} variant='outlined'>
      <CardContent>
        <Typography variant='h5' component='h2'>
          {titulo}
        </Typography>
        <Typography className={classes.pos} color='textSecondary' />
        <Typography variant='body2' className={classes.pos} component='p'>
          $ {valor}
        </Typography>
      </CardContent>
      {/* <CardActions>
        <Button size='small'>Learn More</Button>
      </CardActions> */}
    </Card>
  )
}
