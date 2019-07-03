import React from 'react';
import { enthusiasm } from './index'
import { INCREMENT_ENTHUSIASM } from '../constants/index';


it('Reducer for Increment Enthusiasm', () => {
    let test1 = {languageName: 'Test1', enthusiasmLevel: 20}
    test1 = enthusiasm(test1,{type: INCREMENT_ENTHUSIASM })
    expect(test1).toEqual({languageName: 'Test1', enthusiasmLevel: 21})
});

