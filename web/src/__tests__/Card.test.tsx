import Enzyme, { shallow } from 'enzyme'
import Adapter from '@wojtekmaj/enzyme-adapter-react-17'
import { Typography } from '@material-ui/core'
import Card from '../components/card'

Enzyme.configure({ adapter: new Adapter() })

it('Card loads', () => {
  const wrapper = shallow(<Card titulo='Teste' valor={10} />)
  const text = wrapper.find(Typography).at(0).text()
  expect(text).toEqual('Teste')
})
